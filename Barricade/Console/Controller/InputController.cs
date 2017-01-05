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
        private List<Field> _previousSteps;

        public InputView InputView
        {
            get;
            set;
        }

        private GameController _gameController;

        public InputController(GameController gameController)
        {
            _gameController = gameController;
            _previousSteps = new List<Field>();

            InputView = new InputView(this, gameController);
        }

        public void Move(Pion currentPion, int steps)
        {
            _previousSteps = new List<Field>();

            for (int i = steps; i > 0; i--)
            {
                while (true)
                {
                    _gameController.BoardView.Print();
                    ConsoleKeyInfo key = InputView.GetMoveKey();

                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        Field nextField = currentPion.Field.Up;
                        if (nextField == null || 
                            _previousSteps.Contains(nextField)) continue;

                        while (nextField is StartField)
                        {
                            nextField = nextField.Up;
                        }

                        currentPion.Field.SetPion(null);
                        currentPion.SetField(nextField);
                        _previousSteps.Add(nextField);
                        break;
                    }

                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        Field nextField = currentPion.Field.Right;
                        if (nextField == null ||
                            _previousSteps.Contains(nextField)) continue;

                        currentPion.Field.SetPion(null);
                        currentPion.SetField(nextField);
                        _previousSteps.Add(nextField);
                        break;
                    }

                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        Field nextField = currentPion.Field.Down;
                        if (nextField == null ||
                            _previousSteps.Contains(nextField)) continue;

                        if (nextField is StartField) continue;

                        currentPion.Field.SetPion(null);
                        currentPion.SetField(nextField);
                        _previousSteps.Add(nextField);
                        break;
                    }

                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        Field nextField = currentPion.Field.Left;
                        if (nextField == null ||
                            _previousSteps.Contains(nextField)) continue;

                        currentPion.Field.SetPion(null);
                        currentPion.SetField(nextField);
                        _previousSteps.Add(nextField);
                        break;
                    }

                    InputView.ShowWrongKey();
                }
            }
        }

        public int ThrowDice()
        {
            Random random = new Random();
            int result = random.Next(1, 7);

            InputView.ShowDice(result);

            return result;
        }

        public Pion GetPion()
        {
            InputView.ShowPossiblePions();

            bool inputIsValid = false;
            int turn = _gameController.Turn % 4;

            while (!inputIsValid)
            {
                ConsoleKeyInfo key = InputView.GetPionKey();

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

                InputView.ShowWrongKey();
            }

            throw new Exception("Unreachable Code");
        }
    }
}
