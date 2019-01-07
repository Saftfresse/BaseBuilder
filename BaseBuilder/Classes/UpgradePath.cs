using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBuilder.Classes
{
    class UpgradePath
    {
        List<GameObject> path;

        public UpgradePath()
        {
            path = new List<GameObject>();
        }

        public List<GameObject> Path()
        {
            return path;
        }

        public GameObject Next(GameObject obj)
        {
            return path.ElementAt(path.IndexOf(obj) + 1);
        }
        
        public GameObject Previous(GameObject obj)
        {
            return path.ElementAt(path.IndexOf(obj) - 1);
        }
    }
}
