using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote_Healthcare.DataHandling
{
    class Entity
    {
        public string name;
        public string uuid;
        public string type;
        public Entity(string name, string uuid, string type)
        {
            this.name = name;
            this.uuid = uuid;
            this.type = type;
        }
    }
}
