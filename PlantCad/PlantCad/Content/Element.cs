using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantCad.DB.Mongo;

namespace PlantCad.Content
{
    class Element
    {
        public List<Attribute> Attributes;
        public List<Action> Actions;
        public List<Element> SubElements;

        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                MongoDBContext mdbc = new MongoDBContext("localhost", "test");
                if (!mdbc.Exist(value))
                name = value;
            }
        }


    }
}
