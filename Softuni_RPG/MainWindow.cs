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
    public partial class MainWindow : Form
    {
        private Player player = new Player("Student");
     
        private World world = new World(@"..\..\Map_and_World\Maps\");
        private Map map;

        private bool inBattle = false;

        public MainWindow()
        {
            InitializeComponent();
            player.X = 9;
            player.Y = 8;
            ItemGenerator();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            map = world.CurrentMap();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.DoubleBuffered = true;
            Graphics graphics = e.Graphics;
            Cell[,] cells = map.Cells;
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    graphics.DrawImage(cells[row, col].Image, new Point(col * 64, row * 64));
                }
            }

            graphics.DrawImage(this.player.Image, new Point(player.X * 64, player.Y * 64));

            if (inBattle)
            {
                graphics.DrawImage(Image.FromFile(@"..\..\Resources\battle.jpg"), new Point(0, 0));
            }

            base.OnPaint(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                //TODO: Check what is there on the cell
                case 'w':
                    if (player.Y != 0)
                    {
                        if (this.map.Cells[player.Y - 1, player.X].IsPassable)
                        {
                            player.Y--;
                            if (this.map.Cells[player.Y, player.X].IsOccupied)
                            {
                                HandleCollision();
                            }
                        }
                    }
                    break;
                case 's':
                    if (player.Y != 9)
                    {
                        if (player.Y != 0)
                        {
                            if (this.map.Cells[player.Y + 1, player.X].IsPassable)
                            {
                                player.Y++;
                                if (this.map.Cells[player.Y, player.X].IsOccupied)
                                {
                                    HandleCollision();
                                }
                            }
                        }
                    }
                    break;
                case 'a':
                    if (player.X != 0)
                    {
                        if (this.map.Cells[player.Y, player.X - 1].IsPassable)
                        {
                            player.X--;
                            if (this.map.Cells[player.Y, player.X].IsOccupied)
                            {
                                HandleCollision();
                            }
                        }
                    }
                    break;
                case 'd':
                    if (player.X != 9)
                    {
                        if (this.map.Cells[player.Y, player.X + 1].IsPassable)
                        {
                            player.X++;
                            if (this.map.Cells[player.Y, player.X].IsOccupied)
                            {
                                HandleCollision();
                            }
                        }
                    }
                    break;
                case 'i':
                    var inv = new Inventory(this.player);
                    inv.ShowDialog();
                    break;



            }
            this.Refresh();
        }

        private void HandleCollision()
        {
            switch (this.map.Cells[player.Y, player.X].Occupator.Collision())
            {
                case "battle":
                    //this.inBattle = true;
                    //TODO testing method with enemy and other cahrdcored values
                    Enemy enem = new Enemy("Dragan",100);                 
                    enem.HP = 20;
                    player.HP = 20;
       
                    var battle = new Battle(this.player,enem);
                    battle.ShowDialog();

                    break;
                case "item":
                    //TODO:
                    break;
            }
        }

        private void ItemGenerator()
        {
            this.player.AddItem(new EquipableItem("Bozdugan",@"..\..\Resources\Iron_Axe.png", 300,0));
            this.player.AddItem(new EquipableItem("Armor",@"..\..\Resources\Iron_Axe.png",0, 350));
            this.player.AddItem(new EquipableItem("Helm",@"..\..\Resources\Iron_Axe.png",0, 50));
            this.player.AddItem(new EquipableItem("Bradva",@"..\..\Resources\Iron_Axe.png", 200,0));

        }
    }
}
