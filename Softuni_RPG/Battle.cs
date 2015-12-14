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
        private List<string> spells;
        private List<Rectangle> recs;
        private int additionalPointsBetweenLabels = 15;
        public Battle(Player player, Enemy enemy)
        {
            InitializeComponent();
            this.Player = player;
            this.Enemy = enemy;
            this.labels = new List<Label>();
            this.spellBoard=new List<Rectangle>();
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

            DrawLabels();
            DrawPlayerSpells();
            base.OnLoad(e);
        }

        private void BattleExecution()
        {
            //by default players starts first
            bool playersTurn = true;
            while (true)
            {
                if (playersTurn)
                {
                    playersTurn = false;
                }
                else
                {
                    playersTurn = true;
                }
                if (this.Player.HP <= 0 || this.Enemy.HP <= 0)
                {
                    break;
                }

            }

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
            enemyDefenseUI.Text = string.Format("Enemy Defence Points Left: {0}", this.Enemy.Defense);
            playerNameUI.Text = string.Format("Player Name : {0}", this.Player.Name);
            playerAttackUI.Text = string.Format("Player Attack Points Left: {0}", this.Player.Attack);
            playerDefenseUI.Text = string.Format("Player Defence Points Left: {0}", this.Player.Defense);
            DrawPlayerSpells();
        }

        private void DrawPlayerSpells()
        {
            int X = 10;
            int Y = this.additionalPointsBetweenLabels;
            int interval = 30;
            var spellContainerPoint = new Point(X, Y);
            var spellContainerSize = new Size(interval, interval);
            for (int i = 0; i < 5; i++)
            {
                spellContainerPoint.X = X + (i * interval);
                for (int j = 0; j < 2; j++)
                {
                    spellContainerPoint.Y = Y + (j * interval);
                    var spellContainer = new Rectangle(spellContainerPoint, spellContainerSize);
                    this.spellBoard.Add(spellContainer);
                   
                }
            }
            this.spells=new List<string>();
            this.recs = new List<Rectangle>();
            int spellsCount = 0;
            foreach (var spell in this.Player.Spells)
            {
                spells.Add(spell.Name);
                var tempRect = new Rectangle(this.spellBoard[spellsCount].X + 10, this.spellBoard[spellsCount].Y + 10,
                    this.spellBoard[spellsCount].Width - 10,
                    this.spellBoard[spellsCount].Height - 10);
                this.recs.Add(tempRect);
                spellsCount++;
            }

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            Pen pen = new Pen(Color.Yellow);
            foreach (var spell in this.spellBoard)
            {
                graphics.DrawRectangle(pen,spell);
            }
            for (int i = 0; i < this.spells.Count(); i++)
            {

                //TODO fix constructor font
                graphics.DrawString(this.spells[i], new Font("Verdana", 10.0f), new SolidBrush(Color.Yellow), this.recs[i]);
            }


            base.OnPaint(e);
        }
    }
}
