using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace _8_queens
{
    internal static class Text
    {
        public static char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public static int InputBoardSize(string message)
        {
            Console.Write(message);

            while (true)
            {
                int input;
                if (int.TryParse(Console.ReadLine(), out input) && input > 0 && input <= alpha.Length)
                    return input;
                Console.Write($"Please enter a value greater than zero and less than {alpha.Length}: ");
            }
        }

        public static BoardPosition InputBoardPosition(string message, int boardSize)
        {
            Console.Write(message);

            while (true)
            {
                string input = Console.ReadLine();
                
                char columnDisplay = char.ToUpper(input[0]);
                int column = Array.IndexOf(alpha, columnDisplay);

                if (int.TryParse(input.Substring(1), out int rowDisplay))
                {
                    int row = rowDisplay - 1; // convert 1-based to 0-based
                    BoardPosition pos = new BoardPosition(row, column);
                    if (pos.isValid(boardSize))
                        return pos;
                }
                Console.Write("Please enter a valid position (such as: \"a5\"): ");
            }
        }

        public static class Board
        {
            public static void PrintColumnHeaders(int length)
            {
                Console.Write($"   ");
                for (int i = 0; i < length; i++)
                    Console.Write($" {alpha[i]}");
                Console.WriteLine();
            }

            public static void PrintRow(int row, int length, int queenPosition = -1)
            {
                int displayRow = row + 1;
                if (displayRow < 10)
                    Console.Write($"  {displayRow}");
                else
                    Console.Write($" {displayRow}");

                for (int i = 0; i < length; i++)
                {
                    if (queenPosition == i)
                        Console.Write(" *");
                    else
                        Console.Write(" -");
                }
                Console.WriteLine();
            }
        }
    }
}
