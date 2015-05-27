using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
    public class LifeBoard {
        public bool this[int i, int j] {
            get {
                if (i < 0 || i > _maxWidth || j < 0 || j > _maxHeight)
                    return false;
                else
                    return _board[i, j];
            }
            set {
                _board[i, j] = value;
            }
        }

        private int _maxWidth;
        public int Width {
            get { return _maxWidth; }
        }

        private int _maxHeight;
        public int Height {
            get { return _maxHeight; }
        }

        private bool[,] _board;

        public LifeBoard(int width, int height) {
            _maxWidth = width - 1;
            _maxHeight = height - 1;
            _board = new bool[width, height];
        }

        private void SetBoard(bool[,] board) {
            _board = board;
        }

        public LifeBoard Clone() {
            var board = new LifeBoard(_maxWidth + 1, _maxHeight + 1);
            board.SetBoard((bool[,])_board.Clone());
            return board;
        }
    }
}
