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

        private void DrawPathLine(Field field)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.BackgroundColor = ConsoleColor.Black;

            if (field.Right == null)
            {
                System.Console.WriteLine();
            }
            else
            {
                System.Console.Write("-");
            }
        }

        public void Print()
        {
            var temp = _gameController.Board.Fields;
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Pion != null)
                {
                    Pion pion = temp[i].Pion;
                    System.Console.BackgroundColor = ConsoleColor.DarkGray;

                    if (pion is BluePion)
                    {
                        System.Console.ForegroundColor = ConsoleColor.Blue;

                        if (_gameController.Board.BluePion[0].Equals(pion))
                        {
                            System.Console.Write("Q");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }

                        if (_gameController.Board.BluePion[1].Equals(pion))
                        {
                            System.Console.Write("W");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }

                        if (_gameController.Board.BluePion[2].Equals(pion))
                        {
                            System.Console.Write("A");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }

                        if (_gameController.Board.BluePion[3].Equals(pion))
                        {
                            System.Console.Write("S");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }
                    }

                    if (pion is YellowPion)
                    {
                        System.Console.ForegroundColor = ConsoleColor.Yellow;

                        if (_gameController.Board.YellowPion[0].Equals(pion))
                        {
                            System.Console.Write("E");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }

                        if (_gameController.Board.YellowPion[1].Equals(pion))
                        {
                            System.Console.Write("R");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }

                        if (_gameController.Board.YellowPion[2].Equals(pion))
                        {
                            System.Console.Write("D");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }

                        if (_gameController.Board.YellowPion[3].Equals(pion))
                        {
                            System.Console.Write("F");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }
                    }

                    if (pion is RedPion)
                    {
                        System.Console.ForegroundColor = ConsoleColor.Red;

                        if (_gameController.Board.RedPion[0].Equals(pion))
                        {
                            System.Console.Write("T");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }

                        if (_gameController.Board.RedPion[1].Equals(pion))
                        {
                            System.Console.Write("G");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }

                        if (_gameController.Board.RedPion[2].Equals(pion))
                        {
                            System.Console.Write("Y");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }

                        if (_gameController.Board.RedPion[3].Equals(pion))
                        {
                            System.Console.Write("H");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }
                    }

                    if (pion is GreenPion)
                    {
                        System.Console.ForegroundColor = ConsoleColor.Green;

                        if (_gameController.Board.GreenPion[0].Equals(pion))
                        {
                            System.Console.Write("U");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }

                        if (_gameController.Board.GreenPion[1].Equals(pion))
                        {
                            System.Console.Write("I");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }

                        if (_gameController.Board.GreenPion[2].Equals(pion))
                        {
                            System.Console.Write("J");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }

                        if (_gameController.Board.GreenPion[3].Equals(pion))
                        {
                            System.Console.Write("K");

                            DrawPathLine(temp[i]);

                            i++;
                            continue;
                        }
                    }

                    continue;
                }

                System.Console.ForegroundColor = ConsoleColor.White;

                if (temp[i] is VoidField)
                {
                    System.Console.Write("  ");
                }
                if (temp[i] is EndField)
                {
                    System.Console.Write("F");
                    DrawPathLine(temp[i]);
                }
                if (temp[i] is RegularField && temp[i].Barricade == null)
                {
                    if (temp[i].Pion == null)
                    {
                        System.Console.Write("O");
                        DrawPathLine(temp[i]);
                    }

                }
                if (temp[i] is RestField)
                {
                    if (temp[i].Pion == null)
                    {
                        System.Console.Write("R");
                        DrawPathLine(temp[i]);
                    }

                }
                if (temp[i] is RegularField && temp[i].Barricade != null)
                {
                    if (temp[i].Pion == null)
                    {
                        System.Console.Write("X");
                        DrawPathLine(temp[i]);
                    }

                }
                if (temp[i] is ForestField)
                {
                    System.Console.Write("|   F   | \n");
                }

            }
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
