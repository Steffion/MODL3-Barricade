using Console.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.View
{
    class BoardView
    {
        private GameController _gameController { get; set; }

        public BoardView(GameController gameController)
        {
            _gameController = gameController;
        }

        public void Print()
        {
            Field origin = _gameController.Board.Origin;

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("-------------------------");
            System.Console.WriteLine("|           F           |");
            System.Console.WriteLine("| 	    |	        |");
            System.Console.WriteLine("|   O-O-O-O-O-O-O-O-O   | (1) (9)");
            System.Console.WriteLine("|   |     	    |   |");
            System.Console.WriteLine("|   O-O-O-O-O-O-O-O-O   | (2) (9)");
            System.Console.WriteLine("|           |           |");
            System.Console.WriteLine("|     O-O-O-O-O-O-O     | (3) (7) ");
            System.Console.WriteLine("|     |           |     |");
            System.Console.WriteLine("|     O-O-O-O-O-O-O     | (4) (7)");
            System.Console.WriteLine("|           |           |");
            System.Console.WriteLine("|       O-O-O-O-O       | (5) (4)");
            System.Console.WriteLine("|       | F F F |       |");
            System.Console.WriteLine("| O-O-O-O-O-O-O-O-O-O-O | (6) (11)");
            System.Console.WriteLine("| |   |     |     |   | |");
            System.Console.WriteLine("| O-O-O-O-O-O-O-O-O-O-O |");
            System.Console.WriteLine("|   |   |       |   |   |");
            System.Console.WriteLine("|  B(4) Y(4)  R(4)  G(4)|");
            System.Console.WriteLine("-------------------------");
        }
    }
}
