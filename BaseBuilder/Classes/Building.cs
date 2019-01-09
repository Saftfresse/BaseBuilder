using System;
using System.Collections.Generic;
using System.Drawing;
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
        Requirements reqs;


        double health = 100.0;
        double baseCost = 500.0;

        bool unlocked = false;
        
        Rectangle bounds;

        public Building()
        {

        }
        
        public Building(UpgradePath _path)
        {
            path = _path;
            SetBasePath();
        }

        public Building CurrentUpgrade()
        {
            return (Building)path.Path().ElementAt(level);
        }

        public virtual void applyValues(Building b)
        {
            stats = b.stats;
            health = b.health;
            baseCost = b.baseCost;
            Title = b.Title;
            Text = b.Text;
            Id = b.Id;
        }

        internal void SetBasePath()
        {
            applyValues((Building)path.Path()[level]);
        }

        public Building NextUpgrade()
        {
            try
            {
                return (Building)path.Next(path.Path()[level]);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual void Upgrade()
        {
            Building next = NextUpgrade();
            if (next != null)
            {
                applyValues(next);
                level++;
            }
        }

        public UpgradePath UpgradePath { get => path; set => path = value; }
        public int Level { get => level; set => level = value; }
        public double Health { get => health; set => health = value; }
        public double BaseCost { get => baseCost; set => baseCost = value; }
        public Rectangle Bounds { get => bounds; set => bounds = value; }
        public bool Unlocked { get => unlocked; set => unlocked = value; }
        internal Requirements Requirements { get => reqs; set => reqs = value; }
    }
}
