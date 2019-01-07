using System;
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
        Person instructor = new Person();
        Bitmap draw;


        public Base()
        {
            Buildings.Add(new CentralBuilding(new UpgradePath(
                new List<GameObject>() {
                    new CentralBuilding() { Id = 1, Title = "Small Tent", Text = "Just a small tent for basic Survival", BaseCost = 24.99, Health = 97, CitizenCap = 3, Unlocked = true },
                    new CentralBuilding() { Id = 2, Title = "Wooden Shack", Text = "Basic shelter for you and a few people", BaseCost = 230, Health = 100, CitizenCap = 8, Unlocked = false } })
                    ));
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
                image.FillRectangle(new SolidBrush(Buildings[0].Id == 1?Color.Green:Color.Brown), Buildings[0].Bounds);
            }


            return draw;
        }

        internal Person Instructor { get => instructor; set => instructor = value; }
        internal List<Building> Buildings { get => buildings; set => buildings = value; }
    }
}
