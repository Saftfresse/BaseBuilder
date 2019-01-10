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
        int speed = 37;
        int speedMulti = 1;
        Building selectedBuilding;

        // Lokale Variablen

        // Methoden

        async void MainLoop()
        {
            while (true)
            {
                if (time.AddSeconds(speed).Hour != time.Hour)
                {
                    if (Base.HoursForNextIncome > 1) Base.HoursForNextIncome--;
                    else {
                        Base.ApplyIncome();
                    }
                }
                time = time.AddSeconds(speed);
                Text = time.ToShortDateString() + "    " + time.ToShortTimeString();
                Base.TickUpdate();
                UpdateInformations();
                canvas_time.Invalidate();
                await Task.Delay(50 / speedMulti);
            }
        }

        void UpdateStatsAndResources()
        {
            label_income.Text = "Next Income: " + Base.HoursForNextIncome + " hrs";
            label_level.Text = "Level " + Base.Level;
            label_xp.Text = string.Format("{0} XP", Base.Experience);
            label_resource_gold.Text = Base.Gold.Amount.ToString();
            label_resource_wood.Text = Base.Wood.Amount.ToString();
            label_inventory_gold.Text = Base.Gold.Amount.ToString();
            label_inventory_wood.Text = Base.Wood.Amount.ToString();
            label_resource_income_gold.Text = Base.Gold.Income.ToString();
            label_resource_income_wood.Text = Base.Wood.Income.ToString();
        }

        void UpdateInformations()
        {
            UpdateStatsAndResources();
            if (selectedBuilding != null)
            {
                label_info_title.Text = selectedBuilding.Title;
                label_info_text.Text = selectedBuilding.Text;
                if (selectedBuilding.Id == 1)
                {
                    Base.Instructor.UnlockLineAndJumpTo(3);
                    label_person.Text = Base.Instructor.CurrentLine();
                }
                if (selectedBuilding is CentralBuilding)
                {
                    CentralBuilding c = (CentralBuilding)selectedBuilding;
                    label_info_text.Text += "\nCitizens: " + c.Citizens + " / " + c.CitizenCap;
                }
            }
            else
            {
                label_info_title.Text = "";
                label_info_text.Text = "";
            }
        }

        void populateInventory()
        {
            flow_items.Controls.Clear();
            foreach (var item in Base.Inventory)
            {
                Panel p = new Panel()
                {
                    Size = new Size(75,80),
                    BorderStyle = BorderStyle.None,
                    Parent = flow_items
                };
                PictureBox pic = new PictureBox()
                {
                    Parent = p,
                    Size = new Size(50,50),
                    Image = item.Key.Img,
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                Label l = new Label()
                {
                    Text = item.Value + "x",
                    Parent = p,
                    Location = new Point(48,18)
                };
                Label ll = new Label()
                {
                    Text = item.Key.Title,
                    Parent = p,
                    Location = new Point(2,50),
                    AutoSize = false,
                    Size = new Size(70,30)
                };
            }
        }

        // Generierte Methoden

        private void Form1_Load(object sender, EventArgs e)
        {
            //Location = Screen.AllScreens[1].WorkingArea.Location;
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
            if (((CentralBuilding)Base.Buildings.Find(x => x is CentralBuilding)).Upgrade())
            {
                Base.Experience += (int)Base.ExperienceCount.Building * Base.Level;
            }
            //Base.CleanUpCitizens();
            UpdateInformations();
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
            selectedBuilding = b;
            UpdateInformations();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (speedMulti < 10)
            {
                speedMulti *= 2;
            }
            else
            {
                speedMulti = 1;
            }
            button2.Text = ">> " + speedMulti + "x >>";
        }

        private void canvas_time_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            int wiTotal = canvas_time.Width;
            double percentage = ((time.Hour / 24.0) + (time.Minute / 60.0) / 24);
            e.Graphics.FillRectangle(new SolidBrush(Color.Green), 0,0, (float)(percentage * wiTotal), canvas_time.Height);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CentralBuilding c = (CentralBuilding)Base.Buildings.Find(x => x is CentralBuilding);
            if (c.Citizens < c.CitizenCap)
            {
                Citizen cit = Base.Citizen.GetRandomCitizen(Classes.Citizen.Sex.Male);
                cit.House = c;
                c.Citizens++;
                Base.Citizen.Citizens.Add(cit);
                Base.Experience += (int)Base.ExperienceCount.CitizenArrived * Base.Level;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Base.Level++;
            UpdateInformations();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Base.Gold.Amount += 13.3;
            UpdateStatsAndResources();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Base.Wood.Amount += 13;
            UpdateStatsAndResources();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Base.Gold.Income += 13.3;
            UpdateStatsAndResources();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Base.Wood.Income += 7;
            UpdateStatsAndResources();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Base.Inventory.AddOrUpdate(Base.Items[0], 1, (id, count) => count + 1);
            Base.Inventory.AddOrUpdate(Base.Items[1], 1, (id, count) => count + 1);
            populateInventory();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Base.Experience >= 100)
            {
                Base.Experience -= 100;
                Base.Level++;
            }
        }
    }
}