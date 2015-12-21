using Softuni_RPG.Map_and_World;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Softuni_RPG.GameObjects.Entities;
using Softuni_RPG.GameObjects.Items;
using Softuni_RPG.GameObjects.Spells;

namespace Softuni_RPG
{
    public partial class MainMenu : Form
    {
        public static bool newGame = false;
        public MainMenu()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newGame = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var credits = new Credits();
            credits.ShowDialog();
            if (credits.showMainMenu)
            {
                this.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
