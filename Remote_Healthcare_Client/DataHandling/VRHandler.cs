using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

using Remote_Healthcare_Client.Bicycle;
using Remote_Healthcare_Client.JsonParse;
using Remote_Healthcare_Client.Noises;
using Remote_Healthcare_Client.VRConnection;

namespace Remote_Healthcare_Client.DataHandling
{
    class VRHandler : IBikeDataListener,IReceiver
    {
        #region Properties
        private static VRHandler Instance;
        private string ApiKey = "";
        private string SessionKey = "";
        private string PcName;
        private string task = "";
        private string oldtask = "";
        private List<Entity> entities;
        private bool @lock;
        private List<String> chatMessages;
        private bool donewithsetup;

        private double tempHeight;

        private TCPConnection connection;
        private BikePoller poller;
        private Thread pollworker;
        #endregion

        public static VRHandler getInstance()
        {
            if(Instance == null)
            {
                Instance = new VRHandler();
            }
            return Instance;
        }

        private VRHandler()
        {
#if !DEBUG
            Process.Start($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/simbat.lnk");
            Thread.Sleep(2000);
#endif
            ConnectToVRServer("145.48.6.10", 6666);
            this.PcName = Environment.UserName;
            entities = new List<Entity>();
            @lock = false;
            
            SerialDataHandler.getInstance().AddSubscriberToHandler(this);
            chatMessages = new List<String>();
            donewithsetup = false;
        }

        public void Disconnect()
        {
            connection.StopConnection();
        }

        public void ConnectToVRServer(String ip, int port)
        {
            connection = new TCPConnection(this, ip, port);
        }

        public void SetupScene(int width, int height)
        {
            // create API key
            connection.SendData(Commands.GetSessions());
            AwaitResponse();

            //establish session
            connection.SendData(Commands.CreateTunnel(this.ApiKey));
            AwaitResponse();

            //reset scene
            ResetScene();
            AwaitResponse();

            //generate terrain
            AddTerrain(width, height);
            AwaitResponse();

            //add bicycle node
            AddBike("Bicycle");
            AwaitResponse();

            //connect camera to bike
            ConfigureCameraNode("Bicycle");
            AwaitResponse();
            Debug.WriteLine("- Connect camera to bicycle");

            //add main terrain node
            AddNode("TerrainNode");
            AwaitResponse();

            //shift terrain node to center
            MoveNode("TerrainNode", new int[] { -(int)(0.5 * width), -0, -(int)(0.5 * height) });
            AwaitResponse();


            //add texture to terrain
            AddTexture("desert_sand_big");
            AwaitResponse();

            //add road to terrain
            AddRoute();

            // Add bike data panel
            CreatePanel();
            AwaitResponse();
            ConnectNodeToNode("Panel", "Bicycle");

            //Let bicycle drive
            DriveRoute();
            //AwaitResponse();

            // Plant a tree
            //PlantTrees(20, width, height);
            //AwaitResponse();

            //Change bicycle speed to number
            ChangeSpeed(0);
            AwaitResponse();

#if DEBUG

            for (int i = 0; i < 14; i++)
            {
                chatMessages.Add($"Message {i}");
            }

            AddDataToPanel(new BikeDataPackage("0", "0", "0", "0", "0"));

#endif
            // print currently active nodes
            PrintNodes();
            donewithsetup = true;
        }

        public void StartBikePoller()
        {
            poller = new BikePoller();
            pollworker = new Thread(new ThreadStart(poller.Start));
            pollworker.Start();
        }

        public void StopBikePoller()
        {
            if (pollworker.IsAlive)
            {
                pollworker.Abort();
                pollworker.Join();
            }
        }

        #region Scene Data Management

        private void ChangeSpeed(int speed)
        {
            SetCurrentStep($"--- Changed speed to {speed} m/s");
            string bikenode = FindUidInEntitiesList("Bicycle");
            connection.SendData(Commands.ChangeRouteFollowSpeed( ((float)speed) / 8f, bikenode));
        }

        private void AddDataToPanel(BikeDataPackage e)
        {
            // Find and clear the panel
            string panelUID = FindUidInEntitiesList("Panel");
            ClearPanel(panelUID);


            SwapPanelBuffer(panelUID);
            ClearPanel(panelUID);
            // Add bike info on the left half of the panel
            AddTextBufferToPanel(panelUID, "Bike Info",                  40, new double[] { 50,  50 }, new float[] { 0, 0, 0, 1 });
            AddTextBufferToPanel(panelUID, $"TIME: {e.time} seconds",    25, new double[] { 50, 100 }, new float[] { 0, 0, 0, 1 });
            AddTextBufferToPanel(panelUID, $"SPEED: {e.rpm} rpm",        25, new double[] { 50, 130 }, new float[] { 0, 0, 0, 1 });
            AddTextBufferToPanel(panelUID, $"ENERGY: {e.energy} m/s",    25, new double[] { 50, 160 }, new float[] { 0, 0, 0, 1 });
            AddTextBufferToPanel(panelUID, $"DISTANCE: {e.distance} km", 25, new double[] { 50, 190 }, new float[] { 0, 0, 0, 1 });
            AddTextBufferToPanel(panelUID, $"DIFFICULTY: {e.power} NM",  25, new double[] { 50, 210 }, new float[] { 0, 0, 0, 1 });

            // Divider in the middle
            AddPanelLine(panelUID, new int[] { 256, 0 }, new int[] { 256, 512 }, new float[] { 0, 0, 0, 1 });

            // Add the chatlog on the right half of the panel
            AddTextBufferToPanel(panelUID, "Chat Log", 40, new double[] { 300, 50 }, new float[] { 0, 0, 0, 1 });
            if(chatMessages.Count > 10)
            {
                int startValue = chatMessages.Count - 10;
                for (int i = 0; i < 10; i++)
                {
                    AddTextBufferToPanel(panelUID, chatMessages[startValue+i], 25, new double[] { 300, 100 + 30*i }, new float[] { 0, 0, 0, 1 });
                }
            }
            else if (chatMessages.Count > 0)
            {
                for (int i = 0; i < chatMessages.Count; i++)
                {
                    AddTextBufferToPanel(panelUID, chatMessages[i], 25, new double[] { 300, 100 + 30 * i }, new float[] { 0, 0, 0, 1 });
                }
            }
            else
            {
                AddTextBufferToPanel(panelUID, "No messages yet", 25, new double[] { 300, 100 }, new float[] { 0, 0, 0, 0.8f });
            }

            // Put the new data onto the panel
            SwapPanelBuffer(panelUID);
        }
        private void AddPanelLine(string panelUID, int[] startPos, int[] endPos, float[] rgba)
        {
            connection.SendData(Commands.DrawLineOnPanel(panelUID, startPos, endPos, rgba));
        }

        private void MoveNode(string guid, int[] offset)
        {
            SetCurrentStep($"--- Offsetting terrain {offset[0]}|{offset[1]}|{offset[2]}");
            string nodeGUID = FindUidInEntitiesList(guid);
            connection.SendData(Commands.MoveNode(nodeGUID, offset));
        }

        private void AddRoute()
        {
            SetCurrentStep("--- Adding route node");
            connection.SendData(Commands.AddRouteNode());
            AwaitResponse();
            SetCurrentStep("--- Adding route to route node");
            connection.SendData(Commands.AddVisualRoad( FindUidInEntitiesList("Route")));
            AwaitResponse();
        }

        private void AddTerrain(int width, int height)
        {
            SetCurrentStep("--- Adding terrain");
            float[,] fheights = new float[width,height];
            float[,] heights = new float[width, height];
            Noise.Seed = /*399;*/ new Random().Next(1, 10000);
            fheights = Noise.Calc2D(width, height, 0.009f);

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    heights[x, y] = fheights[x, y] / 10;
            //TODO: terug aanpassen
            
            connection.SendData(Commands.CreateTerrain( width,height, heights));
        }

        public void ResetScene()
        {
            SetCurrentStep("--- Resetting scene");
            connection.SendData(Commands.ResetScene());
        }

        private void AddNode(string name)
        {
            SetCurrentStep($"--- Adding node {name}");
            connection.SendData(Commands.CreateNode( name));
        }

        private void AddBike(string name)
        {
            SetCurrentStep("--- Adding Bicycle to scene");
            connection.SendData(Commands.AddBicycle(name));
        }

        private void AddTexture()
        {
            SetCurrentStep("--- Adding Textures");
            connection.SendData(Commands.AddTexture( FindUidInEntitiesList("TerrainNode")));
        }
        private void AddTexture(string textureName)
        {
            SetCurrentStep($"--- Adding Texture {textureName}");
            connection.SendData(Commands.AddTexture(FindUidInEntitiesList("TerrainNode"), textureName));
        }

        private void DriveRoute()
        {
            SetCurrentStep("--- Driving route");
            string terrainNode = FindUidInEntitiesList("Route");
            string bicycle = FindUidInEntitiesList("Bicycle");
            connection.SendData(Commands.FollowRoute( terrainNode, bicycle));
        }

        private void ConfigureCameraNode(string parentNodeName)
        {
            SetCurrentStep("--- Finding CameraNode");
            string bicycleNode = FindUidInEntitiesList(parentNodeName); 
            connection.SendData(Commands.FindNode( "Camera"));
            AwaitResponse();
            SetCurrentStep("--- Configuring camera node");
            string cameraNode = FindUidInEntitiesList("Camera");
            connection.SendData(Commands.ConnectCameraToNode( cameraNode, bicycleNode));

        }

        private void CreatePanel()
        {
            SetCurrentStep("--- Creating panel");
            connection.SendData(Commands.CreatePanel());
        }

        private void AddTextBufferToPanel(string panelUID,string text, int size, double[] pos, float[] RGBA)
        {
            SetCurrentStep("--- Adding Text to buffer");
            connection.SendData(Commands.FillBufferWithText(panelUID, text, size, pos, RGBA));
        }

        private void SwapPanelBuffer(string panelUID)
        {
            SetCurrentStep("--- Swapping text buffer");
            connection.SendData(Commands.SwapPanelBuffer(panelUID));
        }

        private void ClearPanel(string panelUID)
        {
            SetCurrentStep("--- Clearing panel");
            connection.SendData(Commands.ClearPanel(panelUID));
        }

        private void ConnectNodeToNode(string childNode, string parentNode)
        {
            SetCurrentStep($"--- Connecting {childNode} to {parentNode}");
            string child = FindUidInEntitiesList(childNode);
            string parent = FindUidInEntitiesList(parentNode);

            connection.SendData(Commands.ConnectCameraToNode(child, parent));
        }

        private void SetPanelText(string panelName, string newText)
        {
            SetCurrentStep("--- Adding Text to panel");
            string panelKey = FindUidInEntitiesList(panelName);

            string uid = FindUidInEntitiesList(panelName);
            connection.SendData(Commands.SetPanelBuffer(uid, newText));
            SetCurrentStep("--- Swapping text buffer");
            connection.SendData(Commands.SwapPanelBuffer(uid));
        }

        private void PlantTrees(int treeCount, double mapWidth, double mapLength)
        {
            Random rnd = new Random();

            for (int i = 0; i < treeCount; i++)
            {
                double mapX = rnd.NextDouble() * mapWidth;
                double mapY = rnd.NextDouble() * mapLength;
                connection.SendData(Commands.GetHeight(mapX, mapY));
                AwaitResponse();
                double mapZ = tempHeight;

                connection.SendData(Commands.AddTree(FindUidInEntitiesList("TerrainNode"), mapX, mapZ, mapY));
                AwaitResponse();
                PrintNodes();

            }
            connection.SendData(Commands.GetScene());
        }

        #endregion

        private void SetCurrentStep(string e)
        {
            task = e;
            oldtask = "";
        }

        private void PrintCurrentStep(string status)
        {
            if (oldtask != task)
            {
                Console.WriteLine($"{task} | {status.ToUpper()}");
            }
            oldtask = task;
        }

        private void PrintNodes()
        {
            Debug.WriteLine("\n--- CURRENT ENTITIES ---");
            Console.WriteLine("\n--- CURRENT ENTITIES ---");
            for (int i = 0; i < entities.Count; i++)
            {
                Debug.WriteLine($"{i} \t {entities[i].name} \t {entities[i].type}");
                Console.WriteLine($"{i} \t {entities[i].name} \t {entities[i].type}");
            }
            Debug.WriteLine("------------------------");
            Debug.WriteLine("------------------------");
        }

        private void AwaitResponse()
        {
            @lock = true;
            while (@lock);
        }

        public string FindUidInEntitiesList(string type)
        {
            string output = null;
            foreach (Entity e in entities)
                if (e.type == type)
                    output = e.uuid;
            return output;
        }

        public void ParseCommand(string e, string command)
        {
            switch (command)
            {
                case "session/list":
                    ApiKey = Jsonparser.GetApiKey(this.PcName, e);
                    //ApiKey = Jsonparser.GetApiKey("johan", e);
                    break;
                case "tunnel/create":
                    SessionKey = Jsonparser.GetSecondApiKey(e);
                    Commands.tunnelKey = this.SessionKey;
                    break;
                case "tunnel/send":
                    ParseTunnelData(e);
                    break;
                    //TODO add case for vr hardware callback (such as buttonpresses)
                default:
                    Environment.Exit(-1);
                    break;
            }
            this.@lock = false;
        }

        private void ParseTunnelData(string e)
        {
            dynamic data = JsonConvert.DeserializeObject(e);
            dynamic tunnelData = data.data.data;
            string command = tunnelData.id;
            string status = tunnelData.status;
            if(!donewithsetup)
            PrintCurrentStep(status);
            
            switch (command)
            {
                case "scene/node/add":
                    if (!command.Contains("node/addl"))
                    {
                        string name = tunnelData.data.name;
                        string uuid = tunnelData.data.uuid;

                        switch(name)
                        {
                            case "TerrainNode":
                                entities.Add(new Entity(name, uuid, "TerrainNode"));
                                break;
                            case "Bicycle": case "bike":
                                entities.Add(new Entity(name, uuid, "Bicycle"));
                                break;
                            case "Panel":
                                entities.Add(new Entity(name, uuid, "Panel"));
                                break;
                            case "Surface":
                                entities.Add(new Entity(name, uuid, "Surface"));
                                break;
                            case "TreeHolder":
                                entities.Add(new Entity(name, uuid, "TreeHolder"));
                                break;
                            default:
                                entities.Add(new Entity(name, uuid, "UnspecifiedNode"));
                                break;
                        }
                    }
                    break;
                case "route/add":
                    string uid = tunnelData.data.uuid;
                    entities.Add(new Entity("Route", uid, "Route"));
                    break;
                case "scene/road/add":
                    string uid1 = tunnelData.uuid;
                    entities.Add(new Entity("Road", uid1, "Road"));
                    break;
                case "scene/node/find":
                    JArray nodeData = tunnelData.data;
                    dynamic tempdata = nodeData[0];
                    string nodeID = tempdata.uuid;
                    entities.Add(new Entity("Camera", nodeID, "Camera"));
                    break;
                case "scene/terrain/getheight":
                    tempHeight = tunnelData.data.height;
                    break;
            }
        }

        public void OnBikeDataReceived(BikeDataPackage e)
        {
            ChangeSpeed(Int32.Parse(e.rpm));
            AddDataToPanel(e);
        }

        public void OnChatMessageReceived(string message)
        {
            chatMessages.Add(message);
        }

        public void IsStringReceived(string message)
        {

            string e = message;

            if (e == "")
                return;

            string command = Jsonparser.GetCommandIdentifier(e);
            if (command.Contains("node") || command.Contains("route") || command.Contains("session") || command.Contains("tunnel") || command.Contains("scene"))
            {
                ParseCommand(e, command);
            }
            else
            {
                //TODO add route for other TCP trafic
            }
        
        }
    }
}
