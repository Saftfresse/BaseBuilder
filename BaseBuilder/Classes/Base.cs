using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBuilder.Classes
{
    class Base
    {
        List<Building> buildings = new List<Building>();
        CitizenManager citizen = new CitizenManager();

        Person instructor = new Person();
        Bitmap draw;
        public Random r = new Random();

        Resource gold = new Resource() { Suffix = "G", Id = 1, Name = "Gold", BaseValue = 1, Text = "The Global currency" };
        Resource wood = new Resource() { Suffix = "x", Id = 2, Name = "Wood", BaseValue = 0.015, Text = "A main component of Buildings" };

        ConcurrentDictionary<GameItem, int> inventory = new ConcurrentDictionary<GameItem, int>();
        List<GameItem> items = new List<GameItem>();

        List<Resource> resources = new List<Resource>();

        int citizenChanceMultiplier = 250;
        int citizenChanceCooldownDuration = 1000;
        int citizenChanceCooldownDurationCurrent = 0;

        int hoursForNextIncome = 2;
        
        public enum ExperienceCount
        {
            Building = 35,
            CitizenArrived = 8
        }

        int level = 1;
        double levelCost = 150;
        double experience = 0.0;
        
        public Base()
        {
            resources.AddRange(new[] { gold, wood });

            Buildings.Add(new CentralBuilding(new UpgradePath(
                new List<GameObject>() {
                    new CentralBuilding() { Id = 1, Title = "Small Tent", Text = "Just a small tent for basic Survival", BaseCost = 24.99, Health = 97, CitizenCap = 3, Unlocked = true, Image = Properties.Resources.military_tent },
                    new CentralBuilding() { Id = 2, Title = "Wooden Shack", Text = "Basic shelter for you and a few people", BaseCost = 230, Health = 100, CitizenCap = 8, Unlocked = false, Image = Properties.Resources.shack },
                    new CentralBuilding() { Id = 3, Title = "Improvised Town Hall", Text = "Wooden Building made to provide shelter and room for city planning", BaseCost = 1300, Health = 100, CitizenCap = 21, Unlocked = false, Image = Properties.Resources.small_hall } })
                    ) { Id = 1});
            
            Buildings.Add(new StorageBuilding(new UpgradePath(
                new List<GameObject>() {
                    new StorageBuilding() { Id = 1, Title = "Small Storage Shack", Text="A Small wooden shack made to store supplies", BaseCost = 120, Health = 100, Unlocked = false, Image = Properties.Resources.shack, Capacities = new List<Resource>() { Resource.Clone(gold, 50), Resource.Clone(wood, 500) } } ,
                    new StorageBuilding() { Id = 1, Title = "Storage Silo", Text = "Made to store big amounts of goods", BaseCost = 2800, Health = 100, Unlocked = false, Image = Properties.Resources.shack, Capacities = new List<Resource>() { Resource.Clone(gold, 190), Resource.Clone(wood, 500) } }
                })) { Id = 2 } );


            items.Add(new GameItem() { Title = "Cloth", Text = "Cloth cut from old shirts and pieces", ValueInGold = 0.02, Img = Properties.Resources.cloth, Status = GameItem.ItemStatus.Utility });
            items.Add(new GameItem() { Title = "String", Text = "Strings found in the wildernes", ValueInGold = 0.02, Img = Properties.Resources.misc_string, Status = GameItem.ItemStatus.Utility });
            items.Add(new GameItem() { Title = "Rusty Nail", Text = "Old rusty nails found in every old building", ValueInGold = 0.01, Img = Properties.Resources.rusty_nails, Status = GameItem.ItemStatus.Junk });
            items.Add(new GameItem() { Title = "Old dirty glass panels", Text = "Some old glass panels found in abandones buildings", ValueInGold = 0.07, Img = Properties.Resources.glass_shards, Status = GameItem.ItemStatus.Junk });
        }
        
        public void ApplyIncome()
        {
            foreach (var item in resources)
            {
                item.Amount += item.Income;
            }
            HoursForNextIncome = r.Next(2, 9);
        }

        public void CleanUpCitizens()
        {
            foreach (var item in citizen.Citizens)
            {
                if (item.House is CentralBuilding)
                {
                    CentralBuilding c = (CentralBuilding)item.House;
                    ((CentralBuilding)c).Citizens = 0;
                }
            }
            foreach (var item in citizen.Citizens)
            {
                if (item.House is CentralBuilding)
                {
                    CentralBuilding c = (CentralBuilding)item.House;
                    ((CentralBuilding)c).Citizens++;
                }
            }
        }

        public void TickUpdate()
        {
            int tickValue = r.Next(0, citizenChanceMultiplier);
            if (tickValue == 1 && citizenChanceCooldownDurationCurrent <= 0)
            {
                CentralBuilding c = (CentralBuilding)buildings.Find(x => x is CentralBuilding);
                if (c.Citizens < c.CitizenCap)
                {
                    Citizen cit = citizen.GetRandomCitizen(Classes.Citizen.Sex.Male);
                    cit.House = c;
                    c.Citizens++;
                    citizen.Citizens.Add(cit);
                    experience += (int)ExperienceCount.CitizenArrived * level;
                    citizenChanceCooldownDurationCurrent = r.Next((int)(citizenChanceCooldownDuration * 0.6), (int)(citizenChanceCooldownDuration * 1.2));
                }
            }
            if (citizenChanceCooldownDurationCurrent > 0) citizenChanceCooldownDurationCurrent--;
        }

        public Building GraphicsClicked(Point pt)
        {
            Building ret = null;
            foreach (var item in Buildings)
            {
                if (item.Bounds.Contains(pt))
                {
                    ret = item; 
                }
            }
            return ret;
        }

        public Bitmap GetBaseDraw(Size sz)
        {
            draw = new Bitmap(sz.Width, sz.Height);
            Buildings[0].Bounds = new Rectangle(draw.Width / 5 * 2, draw.Height / 5 * 2, draw.Width / 5, draw.Width / 5);
            using (var image = Graphics.FromImage(draw))
            {
                image.DrawImage(buildings[0].CurrentUpgrade().Image, buildings[0].Bounds);
            }


            return draw;
        }

        internal Person Instructor { get => instructor; set => instructor = value; }
        internal List<Building> Buildings { get => buildings; set => buildings = value; }
        internal CitizenManager Citizen { get => citizen; set => citizen = value; }
        public double Experience { get => experience; set => experience = value; }
        public int Level { get => level; set => level = value; }
        internal Resource Gold { get => gold; set => gold = value; }
        internal Resource Wood { get => wood; set => wood = value; }
        public int HoursForNextIncome { get => hoursForNextIncome; set => hoursForNextIncome = value; }
        internal List<GameItem> Items { get => items; set => items = value; }
        internal ConcurrentDictionary<GameItem, int> Inventory { get => inventory; set => inventory = value; }
    }
}
