using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_queens
{
    internal class BoardPosition
    { // rather sparsely used, and isn't actually used to store the positions on the actual board object. mainly just for nicer code
        public int Row;
        public int Column;

        public BoardPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public bool isValid(int boardSize)
        {
            bool rowValid = Row >= 0 && Row < boardSize;
            bool columnValid = Column >= 0 && Column < boardSize;
            return rowValid && columnValid;
        }
    }
}
