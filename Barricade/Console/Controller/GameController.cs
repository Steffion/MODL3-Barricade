using Console.View;
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
            while (System.Console.ReadKey() != null)
            {
                BoardView.Print();
            }
        }

        public GameController()
        {
            Board = new Board();
            BoardView = new BoardView(this);
        }

        public BoardView BoardView
        {
            get;
            set;
        }

        public Board Board
        {
            get;
            set;
        }
    }
}
