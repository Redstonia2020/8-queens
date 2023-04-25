using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _8_queens
{
    internal class Board
    {
        public int Size;
        public int[] QueenPositions; // follows the sort of idea that there can only be one queen per row, so there is no need for a 2dim array to store positions

        public Board(int size)
        {
            Size = size;
            QueenPositions = new int[size];
            for (int i = 0; i < QueenPositions.Length; i++)
            {
                QueenPositions[i] = -1;
            }
        }

        public Board(int[] state)
        {
            QueenPositions = state;
            Size = state.Length;
        }

        public void Proceed()
        {
            if (getCurrentRow() == -1)
            {
                Console.WriteLine("Here's a solution:");
                Display();
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < Size; i++)
            {
                if (isValidPlacement(i))
                    PlaceQueen(i).Proceed();
            }
        }

        public Board PlaceQueen(int column)
        {
            int[] updatedPositions = new int[QueenPositions.Length];
            Array.Copy(QueenPositions, updatedPositions, QueenPositions.Length);
            updatedPositions[getCurrentRow()] = column;
            return new Board(updatedPositions);
        }

        private bool isValidPlacement(int pos)
        {
            return isColumnClear(pos) && areDiagonalsClear(pos);
        }

        private bool isColumnClear(int pos)
        {
            for (int i = 0; i < Size; i++)
            {
                int check = QueenPositions[i];
                if (check != -1 && check == pos)
                    return false;
            }

            return true;
        }

        private bool areDiagonalsClear(int pos)
        {
            for (int i = 0; i < Size; i++)
            {
                int check = QueenPositions[i];
                int distance = getCurrentRow() - i;
                if (check != -1 && (check - distance == pos || check + distance == pos))
                    return false;
            }

            return true;
        }

        private int getCurrentRow()
        {
            return Array.IndexOf(QueenPositions, -1);
        }

        public void Display()
        {
            Text.Board.PrintColumnHeaders(Size);
            for (int i = 0; i < Size; i++)
            {
                Text.Board.PrintRow(i, Size, QueenPositions[i]);
            }
        }
    }
}