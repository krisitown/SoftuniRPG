using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Softuni_RPG.Factories;
using Softuni_RPG.GameObjects.Entities;
using Softuni_RPG.GameObjects.Interfaces;
using Softuni_RPG.GameObjects.Items;
using Softuni_RPG.Resources;

namespace Softuni_RPG.Map_and_World
{
    public class Map
    {
        private Cell[,] cells;
        private Image image = Image.FromFile(Constants.woodTileImage);
        private Image wallImage = Image.FromFile(Constants.brickTileImage);
        private Image battleImage = Image.FromFile(Constants.battleTileImage);
        private Image itemImage = Image.FromFile(Constants.itemTileImage);


        public Map(string mathPath)
        {
            InitializeCells(mathPath);
        }

        public Cell[,] Cells
        {
            get { return this.cells; }
            set
            {
                if (value == null) 
                {
                    throw new ArgumentNullException("Cells shouldn't be null");
                }
            }
        }

        private void InitializeCells(string mathPath)
        {
            this.cells = new Cell[10, 10];
            string[] lines = System.IO.File.ReadAllLines(mathPath);
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    switch (lines[row][col])
                    {
                        case '.':
                            this.cells[row,col] = new Cell(true, image);
                            break;
                        case 'x':
                            this.cells[row,col] = new Cell(false, wallImage);
                            break;
                        case 'e':
                            this.cells[row, col] = new Cell(true, Image.FromFile(Constants.enemyImagePath), null,
                                RandomFactory.CreatEnemy());
                            break;
                        case 'i':
                            this.cells[row, col] = new Cell(true, itemImage, RandomFactory.CreateItem()); 
                            break;
                    }
                }
            }
        }
    }
}
