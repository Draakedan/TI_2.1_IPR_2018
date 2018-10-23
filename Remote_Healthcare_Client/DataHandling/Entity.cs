namespace Remote_Healthcare_Client.DataHandling
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
