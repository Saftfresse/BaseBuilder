using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBuilder.Classes
{
    class GameObject
    {
        int id;
        string title;
        string text;

        public string Title { get => title; set => title = value; }
        public string Text { get => text; set => text = value; }
        public int Id { get => id; set => id = value; }
    }
}
