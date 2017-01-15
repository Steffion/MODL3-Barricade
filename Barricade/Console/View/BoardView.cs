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

        private void EndOfRow(Field field)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.BackgroundColor = ConsoleColor.Black;
            if (field.Right == null)
            {
                System.Console.WriteLine();
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
                    System.Console.ForegroundColor = pion.CColor;
                    System.Console.Write(pion.Letter);
                    EndOfRow(temp[i]);
                    continue;
                }
                System.Console.ForegroundColor = ConsoleColor.White;

                if (temp[i] is VoidField || temp[i] is HorizontalField)
                {
                    System.Console.Write(temp[i].Letter);
                    continue;
                }
                else
                {
                    System.Console.Write(temp[i].Letter);
                    EndOfRow(temp[i]);
                    continue;
                }
            }
            if (dice > 0)
            {
                System.Console.Write("Zetten over: " + dice);

            }
           
        }

        public void ShowWinner(Pion currentPion)
        {
            if (currentPion is RedPion)
            {
                System.Console.WriteLine("De winnaar is  Rood!");
            }
            if (currentPion is BluePion)
            {
                System.Console.WriteLine("De winnaar is  Blauw!");
            }
            if (currentPion is YellowPion)
            {
                System.Console.WriteLine("De winnaar is  Geel!");
            }
            if (currentPion is GreenPion)
            {
                System.Console.WriteLine("De winnaar is  Groen!");
            }

        }
    }
}
