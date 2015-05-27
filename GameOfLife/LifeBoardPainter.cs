using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
    public class LifeBoardPainter {
        public void Draw(Graphics g, LifeBoard board) {
            if (board == null)
                return;

            for (int i = 0; i < board.Width; i++) {
                for (int j = 0; j < board.Height; j++) {
                    if(board[i,j])
                        g.FillRectangle(Brushes.Black, i*5, j*5, 4, 4);
                    else
                        g.FillRectangle(Brushes.White, i * 5, j * 5, 4, 4);
                }
            }
        }
    }
}
