﻿using Console.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Controller
{
    class GameController
    {
        internal void Start()
        {
            while (true)
            {
                BoardView.Print();
                Pion CurrentPion = InputController.GetPion();

                Turn++;
            }
        }

        public GameController()
        {
            Board = new Board();
            BoardView = new BoardView(this);
            InputController = new InputController(this);
        }

        public BoardView BoardView
        {
            get;
            set;
        }

        public InputController InputController
        {
            get;
            set;
        }

        public Board Board
        {
            get;
            set;
        }

        public int Turn
        {
            get;
            set;
        }
    }
}
