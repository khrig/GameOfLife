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
    }   
}
