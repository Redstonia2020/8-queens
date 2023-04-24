using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _8_queens
{
    internal class BoardState
    {
        public int[] State = new int[8];

        public BoardState()
        {
            for (int i = 0; i < State.Length; i++)
            {
                State[i] = -1;
            }
        }

        public BoardState(int[] state)
        {
            State = state;
        }

        public void Iterate()
        {
            if (GetCurrentRow() == -1)
            {
                Console.WriteLine("A solution:");
                DisplayBoard();
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < 8; i++)
            {
                if (isValidPlacement(i))
                    PlaceQueen(i).Iterate();
            }
        }

        public BoardState PlaceQueen(int column)
        {
            int[] newState = new int[State.Length];
            Array.Copy(State, newState, State.Length);
            newState[GetCurrentRow()] = column;
            return new BoardState(newState);
        }

        private bool isValidPlacement(int column)
        {
            return isColumnClear(column) && areDiagonalsClear(column);
        }

        private bool isColumnClear(int column)
        {
            for (int i = 0; i < GetCurrentRow(); i++)
            {
                if (State[i] == column)
                    return false;
            }

            return true;
        }

        private bool areDiagonalsClear(int column)
        {
            for (int i = 0; i < GetCurrentRow(); i++)
            {
                int distanceAway = GetCurrentRow() - i;
                if (State[i] - distanceAway == column || State[i] + distanceAway == column)
                    return false;
            }

            return true;
        }

        private int GetCurrentRow()
        {
            return Array.IndexOf(State, -1);
        }

        public void DisplayBoard()
        {
            foreach (int columnInRow in State)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (columnInRow == i)
                        Console.Write(" *");
                    else
                        Console.Write(" -");
                }

                Console.WriteLine();
            }
        }
    }
}