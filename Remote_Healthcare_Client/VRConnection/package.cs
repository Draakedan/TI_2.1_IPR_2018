using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Remote_Healthcare_Client.VRConnection
{
    class package
    {
        public String id;
        public package(String id)
        {
            this.id = id;
        }

        public String GetJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
