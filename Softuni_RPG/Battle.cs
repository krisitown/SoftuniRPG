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
using Softuni_RPG.GameObjects.Entities;
using Softuni_RPG.GameObjects.Spells;

namespace Softuni_RPG
{
    public partial class Battle : Form
    {

        private const int battleFormWidth = 700;
        private const int battleFormHeight = 300;
        private const string battleBackgroundDir = @"..\..\Resources\battleBackground.png";

        private Player player;
        private Enemy enemy;
        private List<Label> labels;
        private List<Rectangle> spellBoard;
        private List<string> playersSpellsNames;
        private List<Rectangle> rectangles;
        private int additionalPointsBetweenLabels = 15;

        private bool isPlayersTurn = true;

        public Battle(Player player, Enemy enemy)
        {
            InitializeComponent();
            this.Player = player;
            this.Enemy = enemy;
            this.labels = new List<Label>();
            this.spellBoard = new List<Rectangle>();
        }

        public Player Player { get { return this.player; } private set { this.player = value; } }
        public Enemy Enemy { get; private set; }

        protected override void OnLoad(EventArgs e)
        {

            this.Size = new Size(battleFormWidth, battleFormHeight);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Image.FromFile(battleBackgroundDir);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.DrawLabels();
            this.DrawPlayerSpells();
     

            base.OnLoad(e);
        }

        private void BattleExecution()
        {

            
        }
        private void DrawLabels()
        {
            Label enemyNameUI = new Label();
            Label enemyDefenseUI = new Label();
            Label enemyAttackUI = new Label();
            Label playerNameUI = new Label();
            Label playerDefenseUI = new Label();
            Label playerAttackUI = new Label();
            this.labels.Add(enemyNameUI);
            this.labels.Add(enemyAttackUI);
            this.labels.Add(enemyDefenseUI);
            this.labels.Add(playerNameUI);
            this.labels.Add(playerAttackUI);
            this.labels.Add(playerDefenseUI);


            foreach (var label in this.labels)
            {
                label.Parent = this;
                label.Location = new Point(40, additionalPointsBetweenLabels);
                label.AutoSize = true;
                label.Font = new System.Drawing.Font("Verdana", 10.0f,
                System.Drawing.FontStyle.Bold);
                label.BackColor = System.Drawing.Color.Transparent;
                label.ForeColor = Color.Yellow;
                this.additionalPointsBetweenLabels += 20;
            }
            enemyNameUI.Text = string.Format("Enemy Name : {0}", this.Enemy.Name);
            enemyAttackUI.Text = string.Format("Enemy Attack Points Left: {0}", this.Enemy.Attack);
          //  enemyDefenseUI.Text = string.Format("Enemy Defence Points Left: {0}", this.Enemy.Defense);
            playerNameUI.Text = string.Format("Player Name : {0}", this.Player.Name);
            playerAttackUI.Text = string.Format("Player Attack Points Left: {0}", this.Player.Attack);
       //     playerDefenseUI.Text = string.Format("Player Defence Points Left: {0}", this.Player.Defense);
        }

        private void DrawPlayerSpells()
        {
            int spellsOnRow = 10;
            int rows = 1 + this.Player.Spells.Count / 10;
            int leftSpellForLastRow = this.Player.Spells.Count % 10;
            int X = 10;
            int Y = this.additionalPointsBetweenLabels;
            int interval = 50;
            var spellContainerPoint = new Point(X, Y);
            var spellContainerSize = new Size(interval, interval);
            for (int r = 0; r < rows; r++)
            {
                spellContainerPoint.Y = Y + (r * interval);

                int cols = r == rows - 1 ? leftSpellForLastRow : spellsOnRow;
                for (int c = 0; c < cols; c++)
                {
                    spellContainerPoint.X = X + (c * interval);
                    var spellContainer = new Rectangle(spellContainerPoint, spellContainerSize);
                    this.spellBoard.Add(spellContainer);
                }
            }

            this.playersSpellsNames = new List<string>();
            this.rectangles = new List<Rectangle>();
            int spellsCount = 0;
            foreach (var spell in this.Player.Spells)
            {
                playersSpellsNames.Add(spell.Name);
                var tempRect = new Rectangle(this.spellBoard[spellsCount].X, this.spellBoard[spellsCount].Y,
                    this.spellBoard[spellsCount].Width,
                    this.spellBoard[spellsCount].Height);
                this.rectangles.Add(tempRect);
                spellsCount++;
            }

        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            var mouseRectangle = new Rectangle(e.X, e.Y, 0, 0);
            for (int i = 0; i < this.rectangles.Count; i++)
            {
                if (this.isPlayersTurn && this.rectangles[i].IntersectsWith(mouseRectangle))
                {
                    Spell spellToUse = this.Player.Spells.FirstOrDefault(spell => spell.Name == this.playersSpellsNames[i]);
                    if (spellToUse == null)
                    {
                        throw new ArgumentNullException("Selected spell from board");
                    }
                    //uncomment after players useSpell method implementation;
                    //this.Player.UseSpell(spellToUse,this.Enemy);
                    this.Player.RemoveSpell(spellToUse);

                }
            }
            base.OnMouseDoubleClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            Pen pen = new Pen(Color.Yellow);
            foreach (var spell in this.spellBoard)
            {
                graphics.DrawRectangle(pen, spell);
            }
            for (int i = 0; i < this.playersSpellsNames.Count(); i++)
            {
                graphics.DrawString(this.playersSpellsNames[i], new Font("Verdana", 10.0f), new SolidBrush(Color.Yellow), this.rectangles[i]);
            }


            base.OnPaint(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {

        }
    }
}
