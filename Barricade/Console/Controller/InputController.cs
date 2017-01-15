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
                            
                        if (nextField == null || (i > 1 && nextField.Pion is Barricade)) continue;
                        if (nextField is EndField)
                        {
                            ShowWinner(currentPion);
                        }
                        if (nextField.Pion is Barricade)
                        {
                            MoveBarricade(nextField.Pion);
                            break;
                        }
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
                        if (nextField == null || (i > 1 && nextField.Pion is Barricade) ) continue;
                        if (nextField.Pion is Barricade)
                        {
                            MoveBarricade(nextField.Pion);
                            break;
                        }
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
                        
                        if (nextField == null || nextField is StartField || (i > 1 && nextField.Pion is Barricade || nextField is ForestField)) continue;
                        if (nextField.Pion is Barricade)
                        {
                            MoveBarricade(nextField.Pion);
                            break;
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
                        if (nextField == null || (i > 1 && nextField.Pion is Barricade) ) continue;

                        if (nextField.Pion is Barricade)
                        {
                            MoveBarricade(nextField.Pion);
                            break;
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

        private void ShowWinner(Pion currentPion)
        {
            if (currentPion is RedPion)
            {
                InputView.ShowWinner("Blauw");
            }
            if (currentPion is BluePion)
            {
                InputView.ShowWinner("Rood");
            }
            if (currentPion is YellowPion)
            {
                InputView.ShowWinner("Geel");
            }
            if (currentPion is GreenPion)
            {
                InputView.ShowWinner("Groen");
            }

        }

        private void MoveBarricade(Pion pion)
        {

            Field _tempField = nextField;
            Pion _tempPion = _currentPion;
            Pion __tempPion = null;
            _currentPion = pion;
            _currentPion.SetField(nextField);
            bool _bool = false;
            while (!_bool)
            {
                _gameController.BoardView.Print(0);
                while (true)
                {
                    _gameController.BoardView.Print(0);
                    ConsoleKeyInfo key = InputView.GetMoveKey();
                #region UpArrow
                if (key.Key == ConsoleKey.UpArrow)
                {
                   nextField = _currentPion.Field.Up;
                   if (nextField == null || nextField is EndField) continue;
                        if (__tempPion != null)
                        {
                            _currentPion.Field.SetPion(__tempPion);
                            __tempPion = null;
                            _currentPion.SetField(nextField);
                            break;
                        }
                        if (nextField.Pion != null)
                        {
                            __tempPion = nextField.Pion;
                            _currentPion.Field.SetPion(null);
                            _currentPion.SetField(nextField);
                        }
                        if (nextField.Pion == null)
                        {
                            _currentPion.Field.SetPion(null);
                            _currentPion.SetField(nextField);
                        }
                        if (__tempPion == null)
                        {
                            _currentPion.Field.SetPion(null);
                            _currentPion.SetField(nextField);
                        }
                        if (__tempPion != null)
                        {
                            _currentPion.Field.SetPion(__tempPion);
                            __tempPion = null;
                            _currentPion.SetField(nextField);
                            break;
                        }
                    }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    nextField = _currentPion.Field.Right;
                        if (nextField == null) continue;
                        if (__tempPion != null)
                        {
                            _currentPion.Field.SetPion(__tempPion);
                            __tempPion = null;
                            _currentPion.SetField(nextField);
                            break;
                        }
                        if (nextField.Pion != null)
                        {
                            __tempPion = nextField.Pion;
                            _currentPion.Field.SetPion(null);
                            _currentPion.SetField(nextField);
                        }
                        if (nextField.Pion == null)
                        {
                            _currentPion.Field.SetPion(null);
                            _currentPion.SetField(nextField);
                        }
                        if (__tempPion == null)
                        {
                            _currentPion.Field.SetPion(null);
                            _currentPion.SetField(nextField);
                        }
                        
                    }
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    nextField = _currentPion.Field.Left;
                    if (nextField == null) continue;
                        if (__tempPion != null)
                        {
                            _currentPion.Field.SetPion(__tempPion);
                            __tempPion = null;
                            _currentPion.SetField(nextField);
                            break;
                        }
                        if (nextField.Pion != null)
                        {
                            __tempPion = nextField.Pion;
                            _currentPion.Field.SetPion(null);
                            _currentPion.SetField(nextField);
                        }
                        if (nextField.Pion == null)
                        {
                            _currentPion.Field.SetPion(null);
                            _currentPion.SetField(nextField);
                        }
                        if (__tempPion == null)
                        {
                            _currentPion.Field.SetPion(null);
                            _currentPion.SetField(nextField);
                        }
                        if (__tempPion != null)
                        {
                            _currentPion.Field.SetPion(__tempPion);
                            _tempPion = null;
                            _currentPion.SetField(nextField);
                            break;
                        }

                        break;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    nextField = _currentPion.Field.Down;
                    if (nextField == null || nextField is Model.FirstRow || nextField is ForestField) continue;
                        if (__tempPion != null)
                        {
                            _currentPion.Field.SetPion(__tempPion);
                            __tempPion = null;
                            _currentPion.SetField(nextField);
                            break;
                        }
                        if (nextField.Pion != null)
                        {
                            __tempPion = nextField.Pion;
                            _currentPion.Field.SetPion(null);
                            _currentPion.SetField(nextField);
                        }

                        if (nextField.Pion == null)
                        {
                            _currentPion.Field.SetPion(null);
                            _currentPion.SetField(nextField);
                        }
                        if (__tempPion == null)
                        {
                            _currentPion.Field.SetPion(null);
                            _currentPion.SetField(nextField);
                        }
                        
                    }

                if (key.Key == ConsoleKey.P)
                {
                    if (_currentPion.Field is RestField || _tempPion != null) continue;
                    _bool = true;
                    break;
                }
                InputView.ShowWrongKey();
                }
                #endregion
            }
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
                if (_currentPion.Field.IsInTown)
                {
                    _gameController.Board.Forest.Add(nextField.Pion);
                    _currentPion.Field.SetPion(null);
                    _currentPion.SetField(_gameController.Board.ForestField);
                }
                else
                {
                    BackToSart(nextField.Pion);
                    _currentPion.Field.SetPion(null);
                    _currentPion.SetField(nextField);
                }
               
            }
        }

        private void BackToSart(Pion p)
        {
            var fields = _gameController.Board.Fields;
            int tempInt = 0;
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i] is StartField)
                {
                    if ((tempInt == 0  || tempInt ==  4 || tempInt == 8 || tempInt == 12) && p is BluePion && fields[i].Pion == null)
                    {
                        fields[i].Pion = p;
                        p.Field = fields[i];
                        break;
                    }
                    if ((tempInt == 1 || tempInt == 5 || tempInt == 9 || tempInt == 13) && p is YellowPion && fields[i].Pion == null)
                    {
                        fields[i].Pion = p;
                        p.Field = fields[i];
                        break;
                    }
                    if ((tempInt == 2|| tempInt == 6 || tempInt == 10 || tempInt == 14) && p is GreenPion && fields[i].Pion == null)
                    {
                        fields[i].Pion = p;
                        p.Field = fields[i];
                        break;
                    }
                    if ((tempInt == 3 || tempInt == 7 || tempInt == 11 || tempInt == 15) && p is RedPion && fields[i].Pion == null)
                    {
                        fields[i].Pion = p;
                        p.Field = fields[i];
                        break;
                    }
                    tempInt++;
                }
            }
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
