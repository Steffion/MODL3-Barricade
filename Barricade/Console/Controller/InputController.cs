using Console.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Controller
{
    class InputController
    {
        public InputView InputView
        {
            get;
            set;
        }

        private GameController _gameController;

        public InputController(GameController gameController)
        {
            _gameController = gameController;

            InputView = new InputView(this, gameController);
        }

        internal Pion GetPion()
        {
            InputView.Show();

            bool inputIsValid = false;
            int turn = _gameController.Turn % 4;

            while (!inputIsValid)
            {
                ConsoleKeyInfo key = InputView.GetKey();
                
                switch (turn)
                {
                    case 0:
                        if (key.Key == ConsoleKey.Q)
                        {
                            return _gameController.Board.BluePion[0];
                        }

                        if (key.Key == ConsoleKey.W)
                        {
                            return _gameController.Board.BluePion[1];
                        }

                        if (key.Key == ConsoleKey.A)
                        {
                            return _gameController.Board.BluePion[2];
                        }

                        if (key.Key == ConsoleKey.S)
                        {
                            return _gameController.Board.BluePion[3];
                        }
                        break;
                    case 1:
                        if (key.Key == ConsoleKey.E)
                        {
                            return _gameController.Board.YellowPion[0];
                        }

                        if (key.Key == ConsoleKey.R)
                        {
                            return _gameController.Board.YellowPion[1];
                        }

                        if (key.Key == ConsoleKey.D)
                        {
                            return _gameController.Board.YellowPion[2];
                        }

                        if (key.Key == ConsoleKey.F)
                        {
                            return _gameController.Board.YellowPion[3];
                        }
                        break;
                    case 2:
                        if (key.Key == ConsoleKey.T)
                        {
                            return _gameController.Board.RedPion[0];
                        }

                        if (key.Key == ConsoleKey.Y)
                        {
                            return _gameController.Board.RedPion[1];
                        }

                        if (key.Key == ConsoleKey.G)
                        {
                            return _gameController.Board.RedPion[2];
                        }

                        if (key.Key == ConsoleKey.H)
                        {
                            return _gameController.Board.RedPion[3];
                        }
                        break;
                    case 3:
                        if (key.Key == ConsoleKey.U)
                        {
                            return _gameController.Board.GreenPion[0];
                        }

                        if (key.Key == ConsoleKey.I)
                        {
                            return _gameController.Board.GreenPion[1];
                        }

                        if (key.Key == ConsoleKey.J)
                        {
                            return _gameController.Board.GreenPion[2];
                        }

                        if (key.Key == ConsoleKey.K)
                        {
                            return _gameController.Board.GreenPion[3];
                        }
                        break;
                }

                InputView.WrongKey();
            }

            throw new Exception("Unreachable Code");
        }
    }
}
