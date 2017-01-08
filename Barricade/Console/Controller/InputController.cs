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
        private List<Field> _forestField;
        private Field nextField;
        private Pion _tempPion;
        private Pion _currentPion;

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
            _currentPion = currentPion;
            _previousSteps = new List<Field>();
            _tempPion = null;
            for (int i = steps; i > 0; i--)
            {
                while (true)
                {
                    _gameController.BoardView.Print(i);
                    ConsoleKeyInfo key = InputView.GetMoveKey();
                    #region UpArrow
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        nextField = _currentPion.Field.Up;
                            
                        if (nextField == null || (i >= 1 && nextField.Barricade != null)) continue;
                        while (nextField is StartField)
                        {
                            nextField = nextField.Up;
                        }
                        if (_previousSteps.Contains(nextField))
                        {
                            SetStepBack();
                            i++;
                            InputView.ShowDice(i);
                            continue;
                        }
                        if (nextField.Pion != null)
                        {
                            NextFieldIsPion(i);
                            break;

                        }
                        if (_tempPion != null)
                        {
                            TempPionIsNotNull();
                            break;
                        }
                        if (_tempPion == null)
                        {
                            TempPionIsNull();
                            break;
                        }



                        break;
                    }
                    #endregion
                    #region RightArrow
                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        nextField = _currentPion.Field.Right;
                        if (nextField == null || (i >= 1 && nextField.Barricade != null) ) continue;

                        if (_previousSteps.Contains(nextField))
                        {
                            SetStepBack();
                            i++;
                            InputView.ShowDice(i);
                            continue;
                        }
                        if (_previousSteps.Contains(nextField))
                        {
                            SetStepBack();
                            i++;
                            InputView.ShowDice(i);
                            continue;
                        }
                        if (nextField.Pion != null)
                        {
                            NextFieldIsPion(i);
                            break;

                        }
                        if (_tempPion != null)
                        {
                            TempPionIsNotNull();
                            break;
                        }
                        if (_tempPion == null)
                        {
                            TempPionIsNull();
                            break;
                        }

                    }
                    #endregion
                    #region Keydown
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        nextField = _currentPion.Field.Down;
                        
                        if (nextField == null || nextField is StartField || (i > 1 && nextField.Barricade != null || nextField is ForestField)) continue;
                        if (nextField.Barricade != null)
                        {
                            MoveBarricade();
                            
                        }
                        if (_previousSteps.Contains(nextField))
                        {
                            SetStepBack();
                            i++;
                            InputView.ShowDice(i);
                            continue;
                        }
                        if (nextField.Pion != null)
                        {
                            NextFieldIsPion(i);
                            
                            break;

                        }
                        if (_tempPion != null)
                        {
                            TempPionIsNotNull();
                            
                            break;
                        }
                        if (_tempPion == null)
                        {
                            TempPionIsNull();
                            break;
                        }
                        
                    } 
                    #endregion
                    #region LeftArrow
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        nextField = _currentPion.Field.Left;
                        if (nextField == null || (i > 1 && nextField.Barricade != null) ) continue;

                        if (nextField.Barricade != null)
                        {
                            MoveBarricade();
                        }
                        if (_previousSteps.Contains(nextField))
                        {
                            SetStepBack();
                            i++;
                            InputView.ShowDice(i);
                            continue;
                        }
                        if (nextField.Pion != null)
                        {
                            NextFieldIsPion(i);
                           
                            break;

                        }
                        if (_tempPion != null)
                        {
                            TempPionIsNotNull();
                            
                            break;
                        }
                        if (_tempPion == null)
                        {
                            TempPionIsNull();
                            break;
                        }

                    }
                    #endregion
                    InputView.ShowWrongKey();
                }
            }
        }

        private void MoveBarricade()
        {
            nextField.Barricade = null;
            //TODO something something dat de bariccarde verplaatst.


            _currentPion.Field.SetPion(null);
            _currentPion.SetField(nextField);
        }

        public int ThrowDice()
        {
            Random random = new Random();
            int result = random.Next(1, 7);

            InputView.ShowDice(result);

            return result;
        }
        private void SetStepBack()
        {
            if (_tempPion != null)
            {
                _currentPion.Field.SetPion(_tempPion);
                _tempPion = null;
                _currentPion.SetField(nextField);
            }
            else
            {
                _currentPion.Field.SetPion(null);
                _currentPion.SetField(nextField);
            }
            _previousSteps.RemoveAt(_previousSteps.Count - 1);
        }

        private void TempPionIsNull()
        {
            _currentPion.Field.SetPion(null);
            _currentPion.SetField(nextField);
            _previousSteps.Add(nextField);
        }

        private void TempPionIsNotNull()
        {
            _currentPion.Field.SetPion(_tempPion);
            _tempPion = null;
            _currentPion.SetField(nextField);
            _previousSteps.Add(nextField);
        }

        private void NextFieldIsPion(int i)
        {
            if (i > 1)
            {
                _tempPion = nextField.Pion;
                _currentPion.Field.SetPion(null);
                _currentPion.SetField(nextField);
                _previousSteps.Add(nextField);
            }
            else
            {
                if (CheckIfIsInTown(nextField))
                {
                    _gameController.Board.Forest.Add(nextField.Pion);
                    _currentPion.Field.SetPion(null);
                    _currentPion.SetField(_gameController.Board.ForestField);
                }
                else
                {
                    //TODO iets dat regelt dat de pion terug gaat naar Start 

                    _currentPion.Field.SetPion(null);
                    _currentPion.SetField(nextField);
                    _currentPion.SetField(nextField);
                }
               
            }
        }

        private bool CheckIfIsInTown(Field field)
        {
            for (int y = 0; y < _gameController.Board.Town.Field.Count; y++)
            {
                if (field.Equals(_gameController.Board.Town.Field[y]))
                {
                    _gameController.Board.Forest.Add(nextField.Pion);
                    return true;
                }
            }
            return false;
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
