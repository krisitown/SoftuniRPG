using Softuni_RPG.GameObjects.Entities;
using Softuni_RPG.GameObjects.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Softuni_RPG
{
    public partial class Inventory : Form
    {
        private const int inventoryFormWidth = 600;
        private const int inventoryFormHeight = 700;
        private const string inventoryBackgroundDir = @"..\..\Resources\inventoryBackground.jpg";

        //ITEM CONSTANTS

        private const int startX = 10;
        private const int startY = 40;
        private const int interval = 50;

        //END ITEM CONSTANTS

        private Label playerNameUI;
        private Label playerDefenseUI;
        private Label playerAttackUI;
        private Label playerEquipedItemUI;

        private List<Image> imgs;
        private List<Rectangle> rects;
        private Player player;
        public Button newButton = new Button();
        private Image img;
        private Rectangle rect;
        private List<Rectangle> itemPanel;

        public Inventory(Player player)
        {
            InitializeComponent();
            this.player = player;
            itemPanel = new List<Rectangle>();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Size = new Size(inventoryFormWidth, inventoryFormHeight);

            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;
            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;

            this.BackgroundImage = Image.FromFile(inventoryBackgroundDir);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            var itemContainerPoint = new Point(startX, startY);
            var itemContainerSize = new Size(interval, interval);
            for (int i = 0; i < 5; i++)
            {
                itemContainerPoint.X = startX + (i*interval);
                for (int j = 0; j < 10; j++)
                {
                    itemContainerPoint.Y = startY + (j*interval);
                    var itemContainer = new Rectangle(itemContainerPoint, itemContainerSize);
                    itemPanel.Add(itemContainer);
                }
            }
            imgs = new List<Image>();
            rects = new List<Rectangle>();
            int itemsCount = 0;
            foreach (var item in player.Items)
            {
                imgs.Add(item.ItemImage);
                var tempRect = new Rectangle(itemPanel[itemsCount].X + 10, itemPanel[itemsCount].Y + 10,
                    itemPanel[itemsCount].Width - 10,
                    itemPanel[itemsCount].Height - 10);
                rects.Add(tempRect);
                itemsCount++;
            }



            playerNameUI = new Label();
            playerNameUI.Parent = this;
            playerNameUI.Location = new Point(450, 450);
            playerNameUI.Text = String.Format("Name:{0}", player.Name);
            playerDefenseUI = new Label();
            playerDefenseUI.Parent = this;
            playerDefenseUI.Location = new Point(450, 500);
            playerDefenseUI.Text = String.Format("Defense: {0}", player.Defense);
            playerAttackUI = new Label();
            playerAttackUI.Parent = this;
            playerAttackUI.Location = new Point(450, 530);
            playerAttackUI.Text = String.Format("Attack: {0}", player.Attack);

            playerEquipedItemUI = new Label();
            playerEquipedItemUI.Parent = this;
            playerEquipedItemUI.Location = new Point(450, 560);
            playerEquipedItemUI.Text = String.Format("Item:{0}", player.ItemEquiped!=null?player.ItemEquiped.Name:"None");


            base.OnLoad(e);
        }

        private void RefreshUI()
        {
            playerDefenseUI.Text = String.Format("Defense: {0}", player.Defense);
            playerAttackUI.Text = String.Format("Attack: {0}", player.Attack);
            playerEquipedItemUI.Text = String.Format("Item:{0}", player.ItemEquiped != null ? player.ItemEquiped.Name : "None");
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            var mouseRectangle = new Rectangle(e.X, e.Y, 0, 0);
            for (int i = 0; i < rects.Count(); i++)
            {
                if (rects[i].IntersectsWith(mouseRectangle))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        player.EquipItem((EquipableItem)player.Items[i]);
                    }
                    if (e.Button == MouseButtons.Right)
                    {
                        MessageBox.Show(player.Items.ToString());
                    }
                }
            }
            RefreshUI();

            base.OnMouseClick(e);
        }
    

    public void OnmsClick(object sender, EventArgs args)
        {
            MessageBox.Show("Hello");
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            Pen pen = new Pen(Color.CornflowerBlue);
            foreach (var item in itemPanel)
            {
                graphics.DrawRectangle(pen,item);
            }
            for (int i = 0; i < imgs.Count(); i++)
            {
                graphics.DrawImage(imgs[i],rects[i]);
            }
            

            base.OnPaint(e);
        }

        private void test()
        {
            
        }
    }
}
