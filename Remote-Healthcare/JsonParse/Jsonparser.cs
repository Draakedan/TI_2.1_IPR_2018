using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace Remote_Healthcare.JsonParse
{
    class Jsonparser
    {

        public static string GetCommandIdentifier(string e)
        {
            dynamic keys = JsonConvert.DeserializeObject(e);
            string id = keys.id;
            return id;
        }

        public static string GetNodeUUID(String e)
        {
            bool hasStatus = false;
            /*if (e.Contains("status"))
            {
                hasStatus = true;
            }*/
            
            dynamic keys = JsonConvert.DeserializeObject(e);
            dynamic packdata = keys.data;
            dynamic data = packdata.data;
            String id = data.id;
            if (id.Contains("node/add") && !id.Contains("node/addl"))
            {
                dynamic data2 = data.data;
                return data2.uuid;
            } else
            {
                return null;
            }
        }

        public static string GetApiKey(String name, String input)
        {
            String output = "";
            dynamic keys = JsonConvert.DeserializeObject(input);
            JArray dataArray = keys.data;
            for(int i = 0; i < dataArray.Count; i++)
            {

                dynamic connectioninfo = dataArray[i];
                JObject exinfo = connectioninfo.clientinfo;

                ClientInfo info = exinfo.ToObject<ClientInfo>();

                if(info.user == name)
                {
                    String username = connectioninfo.id;
                    return username;
                }

            }
            output = "Not found";
            return output;
        }

        public static string GetSecondApiKey(String input)
        {
            String output = "";
            dynamic packet = JsonConvert.DeserializeObject(input);
            dynamic data = packet.data;
            output = data.id;
            return output;
        }

    }
}
