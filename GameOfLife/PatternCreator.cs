using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
    public class PatternCreator {
        Random rand;
        public PatternCreator() {
            rand = new Random();
        }

        public void RandomizeBoard(LifeBoard board) {
            for (int i = 0; i < board.Width; i++) {
                for (int j = 0; j < board.Height; j++) {
                    board[i, j] = rand.Next() % 2 == 0 ? true : false;
                }
            }
        }
        
        public void AddBlinker(LifeBoard board, int x, int y) {
            board[x, y] = true;
            board[x, y + 1] = true;
            board[x, y + 2] = true;
        }

        public void AddGlider(LifeBoard board, int x, int y) {
            board[x, y] = true;
            board[x + 1, y + 1] = true;
            board[x + 1, y + 2] = true;
            board[x, y + 2] = true;
            board[x - 1, y + 2] = true;
        }

        public void AddGosperGliderGun(LifeBoard board, int x, int y) {
            board[x, y] = true;
            board[x + 1, y] = true;
            board[x, y + 1] = true;
            board[x + 1, y + 1] = true;

            board[x + 10, y] = true;
            board[x + 10, y + 1] = true;
            board[x + 10, y + 2] = true;

            board[x + 11, y - 1] = true;
            board[x + 11, y + 3] = true;

            board[x + 12, y + 4] = true;
            board[x + 13, y + 4] = true;
            board[x + 12, y - 2] = true;
            board[x + 13, y - 2] = true;

            board[x + 14, y + 1] = true;

            board[x + 15, y - 1] = true;
            board[x + 15, y + 3] = true;

            board[x + 16, y] = true;
            board[x + 16, y + 1] = true;
            board[x + 16, y + 2] = true;

            board[x + 17, y+1] = true;

            board[x + 20, y - 2] = true;
            board[x + 20, y - 1] = true;
            board[x + 20, y] = true;

            board[x + 21, y - 2] = true;
            board[x + 21, y - 1] = true;
            board[x + 21, y] = true;

            board[x + 22, y - 3] = true;
            board[x + 22, y + 1] = true;

            board[x + 24, y - 3] = true;
            board[x + 24, y - 4] = true;
            board[x + 24, y + 1] = true;
            board[x + 24, y + 2] = true;

            board[x + 34, y - 2] = true;
            board[x + 34, y - 1] = true;
            board[x + 35, y - 1] = true;
            board[x + 35, y - 2] = true;
        }
    }   
}
