using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBuilder.Classes
{
    class Requirements
    {
        public Requirements()
        {

        }

        Dictionary<GameItem, int> itemsRequired = new Dictionary<GameItem, int>();
        List<Resource> resourcesRequired = new List<Resource>();

        internal Dictionary<GameItem, int> ItemsRequired { get => itemsRequired; set => itemsRequired = value; }
        internal List<Resource> ResourcesRequired { get => resourcesRequired; set => resourcesRequired = value; }
    }
}
