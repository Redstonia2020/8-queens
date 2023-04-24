using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_queens
{
    internal static class Text
    {
        public static char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public static class Board
        {
            public static void PrintColumnHeaders(int length)
            {
                Console.Write($"  ");
                for (int i = 0; i < length; i++)
                    Console.Write($" {alpha[i]}");
                Console.WriteLine();
            }

            public static void PrintRow(int row, int length, int queenPosition = -1)
            {
                Console.Write($" {row + 1}");
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
