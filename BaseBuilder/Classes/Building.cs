using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBuilder.Classes
{
    class Building:GameObject
    {
        UpgradePath path;
        int level = 0;
        int stats = 10;

        double health = 100.0;
        double baseCost = 500.0;

        public Building()
        {

        }

        public Building NextUpgrade()
        {
            return (Building)path.Next(path.Path()[level]);
        }

        public void Upgrade()
        {
            Building next = NextUpgrade();
            if (next != null)
            {
                stats = next.stats;



                level++;
            }
        }

        internal UpgradePath UpgradePath { get => path; set => path = value; }
        public int Level { get => level; set => level = value; }
    }
}
