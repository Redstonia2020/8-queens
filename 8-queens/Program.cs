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
            Console.WriteLine("(multi-row support coming to stores near you");
            Console.Write("Give column (number) to place queen in first row: ");
            int queenStartColumn = Convert.ToInt32(Console.ReadLine()) - 1;

            BoardState board = new BoardState().PlaceQueen(queenStartColumn);

            Console.WriteLine("Starting board:");
            board.DisplayBoard();
            Console.ReadLine();

            board.Iterate();

            Console.ReadLine();
        }
    }
}
