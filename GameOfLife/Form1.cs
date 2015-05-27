using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife {
    public partial class Form1 : Form {
        private GameOfLife _gameOfLife;
        private LifeBoardPainter _lifeBoardPainter;
        private PatternCreator _patternCreator;
        private LifeBoard currentGeneration;
        private int generation;

        public const int generations = -1;

        public Form1() {
            this.DoubleBuffered = true;
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame() {
            _lifeBoardPainter = new LifeBoardPainter();
            _patternCreator = new PatternCreator();

            var cells = new LifeBoard(128, 96);
            //_patternCreator.RandomizeBoard(cells);
            //_patternCreator.AddGlider(cells, 10, 10);
            _patternCreator.AddGosperGliderGun(cells, 30, 40);

            _gameOfLife = new GameOfLife(cells, generations);
            _gameOfLife.NewGeneration += _gameOfLife_NewGeneration;

            _gameOfLife.Run();
        }
        
        private void _gameOfLife_NewGeneration(object sender, NewGenerationEventArgs e) {
            currentGeneration = e.Generation;
            generation = _gameOfLife.CurrentGeneration + 1;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) {
            lblGenerations.Text = "Generation: " + generation;
            _lifeBoardPainter.Draw(e.Graphics, currentGeneration);
            base.OnPaint(e);
        }
    }
}
