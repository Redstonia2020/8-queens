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
        public int Size;
        public int[] State;

        public BoardState(int size)
        {
            Size = size;
            State = new int[Size];
            for (int i = 0; i < State.Length; i++)
            {
                State[i] = -1;
            }
        }

        public BoardState(int[] state)
        {
            State = state;
            Size = state.Length;
        }

        public void Iterate()
        {
            if (GetCurrentRow() == -1)
            {
                Console.WriteLine("A solution:");
                Display();
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < Size; i++)
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

        private bool isValidPlacement(int target)
        {
            return isColumnClear(target) && areDiagonalsClear(target);
        }

        private bool isColumnClear(int target)
        {
            for (int i = 0; i < Size; i++)
            {
                int check = State[i];
                if (check != -1 && check == target)
                    return false;
            }

            return true;
        }

        private bool areDiagonalsClear(int target)
        {
            for (int i = 0; i < Size; i++)
            {
                int check = State[i];
                int distance = GetCurrentRow() - i;
                if (check != -1 && (check - distance == target || check + distance == target))
                    return false;
            }

            return true;
        }

        private int GetCurrentRow()
        {
            return Array.IndexOf(State, -1);
        }

        public void Display()
        {
            Text.Board.PrintColumnHeaders(Size);
            for (int i = 0; i < Size; i++)
            {
                Text.Board.PrintRow(i, Size, State[i]);
            }
        }
    }
}