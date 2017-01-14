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

        private void DrawPathLine(Field field, int i)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.BackgroundColor = ConsoleColor.Black;

            if (field is StartField) return;

            if (field.Right == null)
            {
                System.Console.WriteLine();
            }
            else
            {
                System.Console.Write("-");
            }
            if (i == 5)
            {
                System.Console.WriteLine("          |");
            }
            if (i == 15)
            {
                 System.Console.WriteLine("  |               |");
            }
            if (i == 25)
            {
                 System.Console.WriteLine("          |");
            }
            if (i == 34)
            {
                 System.Console.WriteLine("    |           |");
            }
            if (i == 43)
            {
                 System.Console.WriteLine("          |");
            }
            if (i == 51)
            {
                System.Console.WriteLine("      |   |   |");
            }
            if (i == 66)
            {
                System.Console.WriteLine("|   |     |     |   |");
            }
            if (i == 77)
            {
                 System.Console.WriteLine("  |   |       |   |");
            }
        }

        public void Print(int dice)
        {
            var temp = _gameController.Board.Fields;
            System.Console.Clear();
            
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Pion != null)
                {
                    Pion pion = temp[i].Pion;
                    System.Console.BackgroundColor = ConsoleColor.DarkGray;
                   
                    if (pion is GreenPion)
                    {
                        System.Console.ForegroundColor = ConsoleColor.Green;

                        if (_gameController.Board.GreenPion[0].Equals(pion))
                        {
                            System.Console.Write("U");

                            if (pion.Field is StartField)
                            {
                                System.Console.ForegroundColor = ConsoleColor.White;
                                System.Console.BackgroundColor = ConsoleColor.Black;
                                System.Console.WriteLine();
                                i++;
                            }
                            else
                            {
                                DrawPathLine(temp[i], i);
                                continue;
                            }

                            
                        }

                        if (_gameController.Board.GreenPion[1].Equals(pion))
                        {
                            System.Console.Write("I");

                            if (pion.Field is StartField)
                            {
                                System.Console.ForegroundColor = ConsoleColor.White;
                                System.Console.BackgroundColor = ConsoleColor.Black;
                                System.Console.WriteLine();
                                i++;
                            }
                            else
                            {
                                DrawPathLine(temp[i], i);
                                continue;
                            }
                        }

                        if (_gameController.Board.GreenPion[2].Equals(pion))
                        {
                            System.Console.Write("J");

                            if (pion.Field is StartField)
                            {
                                System.Console.ForegroundColor = ConsoleColor.White;
                                System.Console.BackgroundColor = ConsoleColor.Black;
                                System.Console.WriteLine();
                                i++;
                            }
                            else
                            {
                                DrawPathLine(temp[i], i);
                                continue;
                            }
                        }

                        if (_gameController.Board.GreenPion[3].Equals(pion))
                        {
                            System.Console.Write("K");

                            if (pion.Field is StartField)
                            {
                                System.Console.ForegroundColor = ConsoleColor.White;
                                System.Console.BackgroundColor = ConsoleColor.Black;
                                System.Console.WriteLine();
                                i++;
                            }
                            else
                            {
                                DrawPathLine(temp[i], i);
                                continue;
                            }
                        }
                    }
                    else
                    {
                        System.Console.ForegroundColor = pion.CColor;
                        System.Console.Write(pion.Letter);
                        DrawPathLine(temp[i], i);
                        continue;
                    }

                }
                

                if (i >= temp.Count) continue;

                System.Console.ForegroundColor = ConsoleColor.White;

                if (temp[i] is VoidField)
                {
                    System.Console.Write(temp[i].Letter);
                    continue;
                }
                if ((temp[i] is RegularField || temp[i] is FirstRow))
                {
                        System.Console.Write("O");
                        DrawPathLine(temp[i], i);
                    continue;
                }
                if (temp[i] is ForestField)
                {
                    System.Console.Write("|   F   | \n");
                    continue;
                }

                if (temp[i] is StartField)
                {
                    System.Console.Write("S");
                    if (i == 88 || i == 99 || i == 121 || i == 110)
                    {
                        System.Console.WriteLine();
                        continue;
                    }
                }
                else
                {
                    System.Console.Write(temp[i].Letter);
                    DrawPathLine(temp[i], i);
                    continue;
                }
            }
            if (dice > 0)
            {
                System.Console.Write("Zetten over: " + dice);

            }
        }
    }
}
