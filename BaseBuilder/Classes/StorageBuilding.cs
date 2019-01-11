using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBuilder.Classes
{
    class StorageBuilding : Building
    {
        public StorageBuilding()
        {

        }

        public StorageBuilding(UpgradePath _path)
        {
            UpgradePath = _path;
            SetBasePath();
        }

        List<Resource> capacities = new List<Resource>();

        internal List<Resource> Capacities { get => capacities; set => capacities = value; }
    }
}
