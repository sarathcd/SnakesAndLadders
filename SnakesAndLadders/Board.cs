using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{

    public interface IBoardFactory
    {
        IBoard CreateBoard();
    }

    public class BoardFactory : IBoardFactory
    {
        private ISquareFactory _squareFactory;
        public BoardFactory(ISquareFactory squareFactory)
        {
            this._squareFactory = squareFactory;
        }
        public IBoard CreateBoard()
        {
            return new Board(this._squareFactory);
        }
    }

    public interface IBoard
    {
        ISquare GetSquare(int squareId);

        ISquare GetWinningSquare();
    }

    public class Board : IBoard
    {
        public List<ISquare> Squares { get; set; }

        public Board(ISquareFactory squareFactory)
        {
            this.Squares = squareFactory.GetSquares();
        }

        public ISquare GetSquare(int squareId)
        {
            return this.Squares.FirstOrDefault(s => s.Id == squareId);
        }

        public ISquare GetWinningSquare()
        {
            return this.Squares.Last();
        }
    }

}
