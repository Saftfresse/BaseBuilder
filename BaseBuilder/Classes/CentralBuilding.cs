using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBuilder.Classes
{
    class CentralBuilding:Building
    {
        int citizens = 0;
        int citizenCap = 1;

        public CentralBuilding()
        {

        }

        public CentralBuilding(UpgradePath _path)
        {
            UpgradePath = _path;
            SetBasePath();
        }

        public int Citizens { get => citizens; set => citizens = value; }
        public int CitizenCap { get => citizenCap; set => citizenCap = value; }
    }
}
