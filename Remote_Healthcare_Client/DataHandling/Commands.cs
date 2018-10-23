using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Remote_Healthcare_Client.DataHandling
{
    class Commands
    {
        public static string tunnelKey;

        /// <summary>
        /// Adds the nessecary wrappers around VR commands as required by the VR Server
        /// </summary>
        /// <param name="commandId">The ID of the command, like "scene/node/add"</param>
        /// <param name="command">"The command to send as new object"</param>
        /// <returns></returns>
        public static string ShortenTunnelSend(string commandId, object command)
        {
            return JsonConvert.SerializeObject(new
            {
                id = "tunnel/send",
                data = new
                {
                    dest = tunnelKey,
                    data = new
                    {
                        id = commandId,
                        data = command
                    }
                }
            });
        }

        /// <summary>
        /// Gets all current active sessions from the server.
        /// </summary>
        /// <returns>The serialised JSON as a string</returns>
        public static string GetSessions()
        {
            //return "{\"id\" : \"session/list\"}";
            return JsonConvert.SerializeObject(new
            {
                id = "session/list"
            });

            
        }

        /// <summary>
        /// Creates a network tunnel between the current application and a VR application.
        /// </summary>
        /// <param name="apiKey">The api key for the session</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string CreateTunnel(string apiKey)
        {
            return JsonConvert.SerializeObject(new
            {
                id = "tunnel/create",
                data = new
                {
                    session = apiKey
                }
            });

            return ShortenTunnelSend("tunnel/create", new
            {
                session = apiKey
            });
        }

        /// <summary>
        /// Creates a node on the scene
        /// </summary>
        /// <param name="name">The name given to the new Node</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string CreateNode(string name)
        {
            return ShortenTunnelSend("scene/node/add", new
            {
                name = name,
                components = new
                {
                    transform = new
                    {
                        position = new JArray { -100, 0, -100 },
                        scale = 1,
                        rotation = new JArray { 0, 0, 0 }

                    },
                    terrain = new
                    {
                        smoothnormals = true
                    }
                }
            });
        }

        /// <summary>
        /// Add a bicycle to the current scene.
        /// </summary>
        /// <param name="name">The name for the Bicyle Node</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string AddBicycle(string name)
        {
            return ShortenTunnelSend("scene/node/add", new
            {
                name = "bike",
                components = new
                {
                    transform = new
                    {
                        position = new[] { 0, 0.15, 0 },
                        scale = 0.01
                    },
                    model = new
                    {
                        file = "data/Networkengine/models/bike/bike_anim.fbx",
                        animated = true,
                        animation = "Armature|Fietsen"
                    }
                }
            });
            #region The Olde Way
            return JsonConvert.SerializeObject(new
            {
                id = "tunnel/send",
                data = new
                {
                    dest = tunnelKey,
                    data = new
                    {
                        id = "scene/node/add",
                        data = new
                        {
                            name = "bike",
                            components = new
                            {
                                transform = new
                                {
                                    position = new[] { 0, 0.15, 0 },
                                    scale = 0.01
                                },
                                model = new
                                {
                                    file = "data/Networkengine/models/bike/bike_anim.fbx",
                                    animated = true,
                                    animation = "Armature|Fietsen"
                                }
                            }
                        }
                    }
                }
            });
            #endregion
        }

        /// <summary>
        /// Delete a given node from the scene.
        /// </summary>
        /// <param name="guid">The UID of the node to be deleted</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string DeleteNode(string guid)
        {
            return ShortenTunnelSend("scene/node/delete", new
            {
                id = guid
            });
        }

        /// <summary>
        /// Updates the node to given value.
        /// </summary>
        /// <param name="tunnelData">The data to send through the tunnel</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string UpdateNode(string tunnelData)
        {
            return ShortenTunnelSend("scene/node/update", new
            {
                id = "guid",
                transform = new
                {
                    position = new[] { 0, 0, 0 },
                    scale = 1.0,
                    rotation = new[] { 0, 0, 0 }
                },
                animation = new
                {
                    name = "walk",
                    speed = 0.5
                }
            });
        }

        /// <summary>
        /// Change the position of a terrain node by a given offset
        /// </summary>
        /// <param name="tunnelKey">The tunnel key for the VR connection</param>
        /// <param name="guid">The Node ID for the terrain</param>
        /// <param name="offset">The offset to move the node with</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string MoveNode(string guid, int[] offset)
        {
            return ShortenTunnelSend("scene/node/update", new
            {
                id = guid,
                transform = new
                {
                    position = new[] { offset[0], offset[1], offset[2] },
                    scale = 1.0,
                    rotation = new[] { 0, 0, 0 }
                }
            });
        }

        /// <summary>
        /// Creates a terrain for things to move on
        /// </summary>
        /// <param name="sizeX">The vertical size of the terrain</param>
        /// <param name="sizeY">The horizontal size of the terrain</param>
        /// <param name="TerrainHeights">The 2D array of the heights of each point in the map</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string CreateTerrain(int sizeX, int sizeY, float[,] TerrainHeights)
        {
            int index = 0;
            float[] fheights = new float[sizeX * sizeY];
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    fheights[index] = TerrainHeights[x, y];
                    index++;
                }
            }

            return ShortenTunnelSend("scene/terrain/add", new
            {
                size = new JArray { sizeX, sizeY },
                heights = fheights
            });
        }

        /// <summary>
        /// Deletes the terrain.
        /// </summary>
        /// <returns>The serialised JSON as a string</returns>
        public static string DeleteTerrain()
        {
            return ShortenTunnelSend("scene/terrain/delete", new
            {

            });
        }

        /// <summary>
        /// Sets a texture on a given node.
        /// (Overloaded with a string for a custom texture)
        /// </summary>
        /// <param name="uuid">The node ID to apply the texture to</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string AddTexture(string uuid)
        {
            string texture = "lava";

            return ShortenTunnelSend("scene/node/addlayer", new
            {
                id = uuid,
                normal = "data/NetworkEngine/textures/terrain/" + texture + "_n.jpg",
                diffuse = "data/NetworkEngine/textures/terrain/" + texture + "_d.jpg",
                minHeight = 0,
                maxHeight = 100,
                fadeDist = 0.5
            });
        }
        public static string AddTexture(string uuid, string textureName)
        {
            string texture = textureName;

            return ShortenTunnelSend("scene/node/addlayer", new
            {
                id = uuid,
                normal = "data/NetworkEngine/textures/terrain/" + texture + "_n.jpg",
                diffuse = "data/NetworkEngine/textures/terrain/" + texture + "_d.jpg",
                minHeight = 0,
                maxHeight = 100,
                fadeDist = 0.5
            });
        }

        /// <summary>
        /// Gets a JSON structure of the scene. The scene is a recursive structure of nodes with all their components
        /// </summary>
        /// <returns>The serialised JSON as a string</returns>
        public static string GetScene()
        {
            return JsonConvert.SerializeObject(new
            {
                id = "scene/get"
            });
        }

        /// <summary>
        /// Resets the scene to starting parameters
        /// </summary>
        /// <returns>The serialised JSON as a string</returns>
        public static string ResetScene()
        {
            return ShortenTunnelSend("scene/reset", new
            {

            });
        }

        /// <summary>
        /// Saves the scene to a file. If overwrite is not specified, or false, the fill will not be overwritten and an error will be returned.
        /// </summary>
        /// <param name="filename">The filename for the new file</param>
        /// <param name="overwrite">Indicates if the file should be overwritten</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string SaveScene(string filename, bool overwrite)
        {
            return ShortenTunnelSend("scene/save", new
            {
                filename = filename,
                overwrite = overwrite
            });
        }

        /// <summary>
        /// Loads a scene from a file
        /// </summary>
        /// <param name="filename">The file to retrieve the scene from</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string LoadScene(string filename)
        {
            return ShortenTunnelSend("scene/load", new
            {
                filename
            });
        }

        /// <summary>
        /// Adds a visual road on top of the terrain
        /// </summary>
        /// <param name="routeUID">The Node ID to be assigned to the Route</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string AddVisualRoad(string routeUID)
        {
            return ShortenTunnelSend("scene/road/add", new
            {
                route = routeUID,
                diffuse = "data/NetworkEngine/textures/tarmac_diffuse.png",
                normal = "data/NetworkEngine/textures/tarmac_normal.png",
                specular = "data/NetworkEngine/textures/tarmac_specular.png",

                heightoffset = 0.01
            });
        }

        /// <summary>
        /// Adds a route on the map
        /// </summary>     
        /// <returns>The serialised JSON as a string</returns>
        public static string AddRouteNode()
        {
            int offsetX = 200;
            int offsetY = 200;
            Random rnd = new Random();

            return ShortenTunnelSend("route/add", new
            {
                nodes = new[]
                {
                    new
                    {
                        pos = new [] {  50 - offsetX, 0, 200 - offsetY},
                        dir = new [] { 0, 0, 500}
                    },
                    new
                    {
                        pos = new[] { 350 - offsetX, 0, 200 - offsetY},
                        dir = new[] { 0, 0, 500}
                    }
                }
            });

            #region Old code, preserved
            /*
            string output = JsonConvert.SerializeObject(new
            {
                id = "tunnel/send",
                data = new
                {
                    dest = tunnelKey,
                    data = new
                    {
                        id = "route/add",
                        data = new
                        {
                            nodes = new[]
                            {
                                // Figure-8 (approx.) 

                                #region old_fig8
                                // Did not get direction vectors working, straight corners for now
                                //new{ pos = new [] {  50 - offsetX, 0, 200 - offsetY }, dir = new[] {   0, 0,   0 }},
                                //new{ pos = new [] {  72 - offsetX, 0, 147 - offsetY }, dir = new[] {   0, 0,   0 }},
                                //new{ pos = new [] { 125 - offsetX, 0, 125 - offsetY }, dir = new[] {   0, 0,   0 }},
                                //new{ pos = new [] { 178 - offsetX, 0, 147 - offsetY }, dir = new[] {   0, 0,   0 }},
                                //new{ pos = new [] { 222 - offsetX, 0, 253 - offsetY }, dir = new[] {   0, 0,   0 }},
                                //new{ pos = new [] { 275 - offsetX, 0, 275 - offsetY }, dir = new[] {   0, 0,   0 }},
                                //new{ pos = new [] { 328 - offsetX, 0, 253 - offsetY }, dir = new[] {   0, 0,   0 }},
                                //new{ pos = new [] { 350 - offsetX, 0, 200 - offsetY }, dir = new[] {   0, 0,   0 }},
                                //new{ pos = new [] { 328 - offsetX, 0, 147 - offsetY }, dir = new[] {   0, 0,   0 }},
                                //new{ pos = new [] { 275 - offsetX, 0, 125 - offsetY }, dir = new[] {   0, 0,   0 }},
                                //new{ pos = new [] { 222 - offsetX, 0, 147 - offsetY }, dir = new[] {   0, 0,   0 }},
                                //new{ pos = new [] { 178 - offsetX, 0, 253 - offsetY }, dir = new[] {   0, 0,   0 }},
                                //new{ pos = new [] { 125 - offsetX, 0, 275 - offsetY }, dir = new[] {   0, 0,   0 }},
                                //new{ pos = new [] {  72 - offsetX, 0, 253 - offsetY }, dir = new[] {   0, 0,   0 }}, 

                                #endregion

                                new
                                {
                                    pos = new [] {  50 - offsetX, 0, 200 - offsetY},
                                    dir = new [] { 0, 0, 500}
                                },
                                new
                                {
                                    pos = new[] { 350 - offsetX, 0, 200 - offsetY},
                                    dir = new[] { 0, 0, 500}
                                }
                            }
                        }
                    }
                }
            });
            return output;
         */

            #endregion
        }

        /// <summary>
        /// Sets a node to follow a premade route
        /// </summary>   
        /// <param name="routeID">The Node ID for the route to be followed</param>
        /// <param name="bikeUID">The node ID for the bike that should follow the path</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string FollowRoute(string routeID, string bikeUID)
        {
            return ShortenTunnelSend("route/follow", new
            {
                route = routeID,
                node = bikeUID,
                speed = 10.0,
                offset = 0.0,
                rotate = "XZ",
                smoothing = 1.0,
                followHeight = true,
                rotateOffset = new[] { 0, 0, 0 },
                positionOffset = new[] { 0, 0, 0 }
            });
        }

        /// <summary>
        /// Changes the speed at which the node follows the route
        /// </summary>
        /// <param name="velocity">Indicates how fast the node moves across the route</param>
        /// <param name="bikenode">Indicates which bike we are talking about</param>
        public static string ChangeRouteFollowSpeed(float velocity, string bikenode)
        {
            return ShortenTunnelSend("route/follow/speed", new
            {
                node = bikenode,
                speed = velocity
            });
        }

        /// <summary>
        /// Asks the server to return a nodeID with a specific name
        /// </summary>
        /// <param name="name">Name of node to find</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string FindNode(string name)
        {
            return ShortenTunnelSend("scene/node/find", new
            {
                name
            });
        }

        /// <summary>
        /// Connects the VR Camera to a Node (usually the bicycle node)
        /// </summary>
        /// <param name="cameraNodeId">The Node ID of the camera</param>
        /// <param name="parentNodeId">The Node ID of the parent node to connect the camera to</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string ConnectCameraToNode(string cameraNodeId, string parentNodeId)
        {
            return ShortenTunnelSend("scene/node/update", new
            {
                id = cameraNodeId,
                parent = parentNodeId,
                transform = new
                {
                    scale = 100
                }
            });
        }

        public static string ClearPanel(string panelUID)
        {
            return ShortenTunnelSend("scene/panel/clear", new
            {
                id = panelUID,
            });
        }

        public static string CreatePanel()
        {
            return ShortenTunnelSend("scene/node/add", new
            {
                name = "Panel",
                components = new
                {
                    transform = new
                    {
                        position = new[] { -34, 121, 1 },
                        rotation = new[] { -90, 90, -40 },
                        scale = 1
                    },
                    panel = new
                    {
                        size = new[] { 0.48, 0.30 },
                        resolution = new[] { 512, 512 }
                    }
                }
            });
        }
        public static string CreatePanel(float width, float height)
        {
            return ShortenTunnelSend("scene/node/add", new
            {
                name = "Panel",
                components = new
                {
                    transform = new
                    {
                        position = new[] { 0, 1, 0 },
                        rotation = new[] { 0, 0, 0 },
                        scale = 1
                    },
                    panel = new
                    {
                        size = new[] { width, height },
                        resolution = new[] { 512, 512 },
                    }
                }
            });
        }

        public static string SetPanelBuffer(string panelId, string newText)
        {
            return ShortenTunnelSend("scene/panel/drawtext", new
            {
                id = panelId,
                text = newText,
                position = new[] { 100, 100 }
            });
        }

        public static string FillBufferWithText(string panelID, string newText, int fontSize, double[] location, float[] rgba)
        {
            return ShortenTunnelSend("scene/panel/drawtext", new
            {
                id = panelID,
                text = newText,
                size = fontSize,
                position = new[] { location[0], location[1] },
                color = new[] { rgba[0], rgba[1], rgba[2], rgba[3] },
                font = "segoeui"
            });
        }

        /// <summary>
        /// Draws a line on the backbuffer of the Panel
        /// </summary>
        /// <param name="panelID">The node ID of the panel</param>
        /// <param name="startPos">The starting position of the line as array { x, y }</param>
        /// <param name="endPos">The end position of the line as array { x, y }</param>
        /// <param name="rgba">The color of the line</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string DrawLineOnPanel(string panelID, int[] startPos, int[] endPos, float[] rgba)
        {
            return ShortenTunnelSend("scene/panel/drawlines", new
            {
                id = panelID,
                width = 2,
                lines = new[]
                {
                    new[] { startPos[0],startPos[1], endPos[0],endPos[1], 0,0,0,1f }, // x1,y1, x2,y2, r,g,b,a
                }
            });
        }

        /// <summary>
        /// Swaps the font and back buffer of the panel
        /// </summary>
        /// <param name="panelId">The node ID of the panel</param>
        /// <returns>The serialised JSON as a string</returns>
        public static string SwapPanelBuffer(string panelId)
        {
            return ShortenTunnelSend("scene/panel/swap", new
            {
                id = panelId
            });
        }

        public static string AddSurface()
        {
            return ShortenTunnelSend("scene/node/add", new
            {
                name = "Surface",
                components = new
                {
                    transform = new
                    {
                        position = new[] { 0, 0, 0 },
                        scale = 1
                    },
                    model = new
                    {
                        file = "data/TienTest/biker/models/ground/landscape.obj"
                    }
                }
            });
        }

        public static string AddForesto()
        {
            return ShortenTunnelSend("scene/node/add", new
            {
                name = "TreeHolder",
                components = new
                {
                    transform = new
                    {
                        position = new[] { 0, 0, 0 },
                        scale = 1
                    }
                }
            });
        }

        public static string AddTree(string parentNodeId, double x, double z, double y)
        {
            Random rnd = new Random();

            return ShortenTunnelSend("scene/node/add", new
            {
                name = "Tree",
                parent = parentNodeId,
                components = new
                {
                    transform = new
                    {
                        position = new[] { x, z, y},
                        rotation = new[] { 0, rnd.NextDouble() * 360, 0 },
                        scale = 1 + 0.4 * rnd.NextDouble()
                    },
                    model = new
                    {
                        file = "data/NetworkEngine/models/trees/fantasy/tree2.obj",
                        cullbackfaces = false
                    }
                }
            });
        }

        public static string GetHeight(double x, double y)
        {
            return ShortenTunnelSend("scene/terrain/getheight", new
            {
                position = new[] {x, y}
            });
        }
    }
}
