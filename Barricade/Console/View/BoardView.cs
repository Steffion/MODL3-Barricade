using Console.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Console.Model;
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
            String printLine = "";
        var temp = _gameController.Board.Fields;
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i] is VoidField)
                {
                    printLine += "  ";
                }
                if(temp[i] is EndField)
                {
                    printLine += "F";
                    if (temp[i].Right == null)
                    {
                        printLine += "\n";
                    }

                }
                if (temp[i] is RegularField && temp[i].Barricade == null)
                {
                    if (temp[i].Pion == null )
                    {
                        printLine += "O";
                        if (temp[i].Right == null)
                        {
                            printLine += "\n";
                        }
                        else
                        {
                            printLine += "-";
                        }
                    }
                   
                }
                if (temp[i] is RestField)
                {
                    if (temp[i].Pion == null)
                    {
                        printLine += "R";
                        if (temp[i].Right == null)
                        {
                            printLine += " \n";
                        }
                        else
                        {
                            printLine += "-";
                        }
                    }

                }
                if (temp[i] is RegularField && temp[i].Barricade != null)
                {
                    if (temp[i].Pion == null)
                    {
                        printLine += "X";
                        if (temp[i].Right == null)
                        {
                            printLine += " \n";
                        }
                        else
                        {
                            printLine += "-";
                        }
                    }

                }
            }
            System.Console.WriteLine(printLine);
            //Field origin = _gameController.Board.Origin;

            //System.Console.ForegroundColor = ConsoleColor.White;
            //System.Console.WriteLine();
            //System.Console.WriteLine();
            //System.Console.WriteLine();
            //System.Console.WriteLine("-------------------------");
            //System.Console.WriteLine("|           F           |");
            //System.Console.WriteLine("| 	    |	        |");
            //System.Console.WriteLine("|   O-O-O-O-O-O-O-O-O   | (1) (9)");
            //System.Console.WriteLine("|   |     	    |   |");
            //System.Console.WriteLine("|   O-O-O-O-O-O-O-O-O   | (2) (9)");
            //System.Console.WriteLine("|           |           |");
            //System.Console.WriteLine("|     O-O-O-O-O-O-O     | (3) (7) ");
            //System.Console.WriteLine("|     |           |     |");
            //System.Console.WriteLine("|     O-O-O-O-O-O-O     | (4) (7)");
            //System.Console.WriteLine("|           |           |");
            //System.Console.WriteLine("|       O-O-O-O-O       | (5) (4)");
            //System.Console.WriteLine("|       | F F F |       |");
            //System.Console.WriteLine("| O-O-O-O-O-O-O-O-O-O-O | (6) (11)");
            //System.Console.WriteLine("| |   |     |     |   | |");
            //System.Console.WriteLine("| O-O-O-O-O-O-O-O-O-O-O |");
            //System.Console.WriteLine("|   |   |       |   |   |");
            //System.Console.WriteLine("|  B(4) Y(4)  R(4)  G(4)|");
            //System.Console.WriteLine("-------------------------");
        }
    }
}
