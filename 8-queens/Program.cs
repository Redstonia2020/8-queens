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
            BoardState board = new BoardState(boardSize);

            Console.WriteLine("Here's what your board looks like:");
            board.Display();

            int placementRow = Text.InputBoardPosition("Based on the above, where would you like to place the first queen? ", out int placementColumn, boardSize);
            board.State[placementRow] = placementColumn;

            Console.WriteLine("Your piece has been placed!");
            board.Display();
            Console.ReadLine();

            board.Iterate();

            Console.ReadLine();
        }
    }
}
