using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBuilder.Classes
{
    class GameItem : GameObject
    {
        Guid uid = Guid.NewGuid();
        Image img = Properties.Resources.attention;
        double valueInGold = 0;
        ItemStatus status = ItemStatus.Common;

        public Guid Uid { get => uid; }
        public Image Img { get => img; set => img = value; }
        public double ValueInGold { get => valueInGold; set => valueInGold = value; }
        internal ItemStatus Status { get => status; set => status = value; }

        public enum ItemStatus
        {
            Junk,
            Utility,
            Common,
            Rare,
            Epic,
            Legendary
        }

        public GameItem()
        {

        }
    }
}
