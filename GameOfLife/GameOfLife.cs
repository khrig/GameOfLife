using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GameOfLife {
    public class GameOfLife {
        private int _generations;
        private LifeBoard _initialState;
        private LifeBoard _currentState;
        private Timer tickTimer;
        private int generationCount = 0;
        private const int tickInterval = 500;

        public event EventHandler<NewGenerationEventArgs> NewGeneration;

        public int CurrentGeneration {
            get { return generationCount; }
        }

        public GameOfLife(LifeBoard initialState, int generations) {
            _initialState = initialState;
            _generations = generations;
        }

        public void Run() {
            generationCount = 0;
            tickTimer = new Timer();
            tickTimer.Elapsed += tickTimer_Elapsed;
            tickTimer.Interval = tickInterval;
            tickTimer.Enabled = true;
            _currentState = _initialState;
            RaiseNewGenerationEvent(_currentState);
        }

        private void tickTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            if (generationCount == _generations) {
                tickTimer.Enabled = false;
                tickTimer.Close();
                return;
            }
            _currentState = Tick(_currentState);
            RaiseNewGenerationEvent(_currentState);
            generationCount++;
        }

        private void RaiseNewGenerationEvent(LifeBoard generation) {
            var handler = NewGeneration;
            if (handler != null) {
                handler(this, new NewGenerationEventArgs(generation));
            }
        }

        private LifeBoard Tick(LifeBoard cells) {
            LifeBoard nextGeneration = cells.Clone();
            for (int i = 0; i < cells.Width; i++) {
                for (int j = 0; j < cells.Height; j++) {
                    nextGeneration[i, j] = Evaluate(cells, i, j);
                }
            }
            return nextGeneration;
        }

        private bool Evaluate(LifeBoard cells, int i, int j) {
            int neighbours = 0;
            if (cells[i - 1, j - 1])
                neighbours++;
            if (cells[i - 1, j])
                neighbours++;
            if (cells[i - 1, j + 1])
                neighbours++;
            if (cells[i, j - 1])
                neighbours++;
            if (cells[i, j + 1])
                neighbours++;
            if (cells[i + 1, j - 1])
                neighbours++;
            if (cells[i + 1, j])
                neighbours++;
            if (cells[i + 1, j + 1])
                neighbours++;

            return IsReborn(cells[i, j], neighbours) || IsStillAlive(cells[i, j], neighbours);
        }

        private bool IsReborn(bool isAlive, int neighbours) {
            return !isAlive && neighbours == 3;
        }

        private bool IsStillAlive(bool isAlive, int neighbours) {
            return isAlive && (neighbours == 2 || neighbours == 3);
        }
    }
}
