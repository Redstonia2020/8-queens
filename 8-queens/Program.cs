using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_queens
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boardSize = Text.InputBoardSize("What size would you like your board to be? ");
            Board board = new Board(boardSize);

            Console.WriteLine("Here's what your board looks like:");
            board.Display();

            BoardPosition placementPos = Text.InputBoardPosition("Based on the above, where would you like to place the first queen? ", boardSize);
            board.QueenPositions[placementPos.Row] = placementPos.Column;

            Console.WriteLine("Your piece has been placed!");
            board.Display();
            Console.ReadLine();

            board.Proceed();

            Console.ReadLine();
        }
    }
}
