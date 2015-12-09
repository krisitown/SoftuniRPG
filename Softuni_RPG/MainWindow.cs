using Softuni_RPG.Entities;
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

namespace Softuni_RPG
{
    public partial class MainWindow : Form
    {
        private Player player = new Player();
        private Image playerImage = Image.FromFile(@"..\..\Resources\code_wizard.png");
        private World world = new World(@"..\..\Map_and_World\Maps\");
        private Map map;
        private int playerX = 9;
        private int playerY = 8;
        private bool inBattle = false;

        public MainWindow()
        {
            InitializeComponent();
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

            graphics.DrawImage(playerImage, new Point(playerX * 64, playerY * 64 - 20));

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
                    if (playerY != 0)
                    {
                        if (this.map.Cells[playerY - 1, playerX].IsPassable)
                        {
                            playerY--;
                            if (this.map.Cells[playerY, playerX].IsOccupied)
                            {
                                HandleCollision();
                            }
                        }
                    }
                    break;
                case 's':
                    if (playerY != 9)
                    {
                        if (playerY != 0)
                        {
                            if (this.map.Cells[playerY + 1, playerX].IsPassable)
                            {
                                playerY++;
                                if (this.map.Cells[playerY, playerX].IsOccupied)
                                {
                                    HandleCollision();
                                }
                            }
                        }
                    }
                    break;
                case 'a':
                    if (playerX != 0)
                    {
                        if (this.map.Cells[playerY, playerX - 1].IsPassable)
                        {
                            playerX--;
                            if (this.map.Cells[playerY, playerX].IsOccupied)
                            {
                                HandleCollision();
                            }
                        }
                    }
                    break;
                case 'd':
                    if (playerX != 9)
                    {
                        if (this.map.Cells[playerY, playerX + 1].IsPassable)
                        {
                            playerX++;
                            if (this.map.Cells[playerY, playerX].IsOccupied)
                            {
                                HandleCollision();
                            }
                        }
                    }
                    break;
            }
            this.Refresh();
        }

        private void HandleCollision()
        {
            switch (this.map.Cells[playerY, playerX].Occupator.Collision())
            {
                case "battle":
                    this.inBattle = true;
                    break;
                case "itme":
                    //TODO:
                    break;
            }
        }
    }
}
