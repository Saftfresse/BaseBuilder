using BaseBuilder.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseBuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //
        // Ziel Basis aufrüsten und Gewinn erziehlen
        // durch Rohstoffe Sammeln & Handeln
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 
        // 


        // Globale Variablen
        Base Base = new Base();
        DateTime time = new DateTime(2130, 6, 12, 8, 30, 5);
        int speed = 13;
        int speedMulti = 1;

        // Lokale Variablen

        // Methoden

        async void MainLoop()
        {
            while (true)
            {
                time = time.AddSeconds(speed * speedMulti);
                Text = time.ToShortDateString() + "    " + time.ToLongTimeString();
                await Task.Delay(50);
            }
        }

        // GEnerierte Methoden
       
        private void Form1_Load(object sender, EventArgs e)
        {
            label_person.Text = Base.Instructor.CurrentLine();
            MainLoop();
        }

        private void label_person_Click(object sender, EventArgs e)
        {
            Base.Instructor.NextLine();
            label_person.Text = Base.Instructor.CurrentLine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Base.Buildings[0].Upgrade();
            canvas.Invalidate();
        }

        private void label_person_TextChanged(object sender, EventArgs e)
        {
            if (label_person.Text.Length <= 0)
            {
                label_person.BackColor = Color.Gray;
            }
            else
            {
                label_person.BackColor = Color.White;
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Base.GetBaseDraw(canvas.Size), 0, 0);
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            Building b = Base.GraphicsClicked(e.Location);
            if (b != null)
            {

                label_info_title.Text = b.Title;
                label_info_text.Text = b.Text;
                if (b.Id == 1)
                {
                    Base.Instructor.UnlockLineAndJumpTo(3);
                    label_person.Text = Base.Instructor.CurrentLine();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (speedMulti < 10)
            {
                speedMulti*=2;
            }
            else
            {
                speedMulti = 1;
            }
            button2.Text = ">> " + speedMulti + "x >>";
        }
    }
}
