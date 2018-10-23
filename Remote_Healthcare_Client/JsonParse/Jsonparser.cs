using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace Remote_Healthcare_Client.JsonParse
{
    class Jsonparser
    {

        public static string GetCommandIdentifier(string e)
        {
            dynamic keys;
            try
            {
                keys = JsonConvert.DeserializeObject(e);
            }
            catch (Exception g)
            {
                string f = e + "}";
                keys = JsonConvert.DeserializeObject(f);

            }
            string id = keys.id;
            return id;
        }

        public static string GetNodeUUID(string e)
        {
            bool hasStatus = false;
            /*if (e.Contains("status"))
            {
                hasStatus = true;
            }*/
            
            dynamic keys = JsonConvert.DeserializeObject(e);
            dynamic packdata = keys.data;
            dynamic data = packdata.data;
            string id = data.id;
            if (id.Contains("node/add") && !id.Contains("node/addl"))
            {
                dynamic data2 = data.data;
                return data2.uuid;
            } else
            {
                return null;
            }
        }

        public static string GetApiKey(string name, string input)
        {
            string output = "";
            dynamic keys = JsonConvert.DeserializeObject(input);
            JArray dataArray = keys.data;
            for(int i = 0; i < dataArray.Count; i++)
            {

                dynamic connectioninfo = dataArray[i];
                JObject exinfo = connectioninfo.clientinfo;

                ClientInfo info = exinfo.ToObject<ClientInfo>();

                if(info.user == name)
                {
                    string username = connectioninfo.id;
                    return username;
                }

            }
            output = "Not found";
            return output;
        }

        public static string GetSecondApiKey(string input)
        {
            string output = "";
            dynamic packet = JsonConvert.DeserializeObject(input);
            dynamic data = packet.data;
            output = data.id;
            return output;
        }

    }
}
