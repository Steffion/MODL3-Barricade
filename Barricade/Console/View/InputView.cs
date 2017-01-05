using Console.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.View
{
    class InputView
    {
        private GameController _gameController { get; set; }
        private InputController _inputController { get; set; }

        public InputView(InputController inputController, GameController gameController)
        {
            _inputController = inputController;
            _gameController = gameController;
        }

        public void Show()
        {
            int turn = _gameController.Turn % 4;

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("This turn is ");

            switch(turn)
            {
                case 0:
                    System.Console.ForegroundColor = ConsoleColor.Blue;
                    System.Console.Write("Blue");
                    break;
                case 1:
                    System.Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.Write("Yellow");
                    break;
                case 2:
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.Write("Red");
                    break;
                case 3:
                    System.Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.Write("Green");
                    break;
            }

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine(":");
        }

        public ConsoleKeyInfo GetKey()
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("Please choose your pion (");

            int turn = _gameController.Turn % 4;

            switch (turn)
            {
                case 0:
                    System.Console.ForegroundColor = ConsoleColor.Blue;
                    System.Console.Write("Q W A S");
                    break;
                case 1:
                    System.Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.Write("E R D F");
                    break;
                case 2:
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.Write("T Y G H");
                    break;
                case 3:
                    System.Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.Write("U I J K");
                    break;
            }

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("):");

            return System.Console.ReadKey();
        }

        public void WrongKey()
        {
            System.Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine();
            System.Console.WriteLine("Wrong key!");
        }
    }
}
