using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{

    public interface IPlayerHelper
    {
        void Initialize(IBoard board, Token token, IDie die);
        void PlaceTokenOnBoard();
        void Play();
        bool HasPlayerWon();
    }

    public class PlayerHelper : IPlayerHelper
    {
        private IBoard _board;
        private Token _token;
        private IDie _die;

        public void Initialize(IBoard board, Token token, IDie die)
        {
            this._board = board;
            this._token = token;
            this._die = die;
        }

        public void PlaceTokenOnBoard()
        {
            var square = _board.GetSquare(1);
            this.setSquare(square);
        }

        public void Play()
        {
            var nextSquare = this._token.Square.Id + this._die.Roll();
            var square = _board.GetSquare(nextSquare);
            if (square != null)
            {
                var oldSquare = this._token.Square;
                oldSquare.RemoveToken(this._token);
                this._token.Square = null;
                this.setSquare(square);
            }
        }

        public bool HasPlayerWon()
        {
            var winningSquare = this._board.GetWinningSquare();
            return winningSquare.ContainsToken(this._token);
        }

        private void setSquare(ISquare square)
        {
            this._token.Square = square;
            square.AddToken(this._token);
        }
    }

    public interface IPlayerHelperFactory
    {
        IPlayerHelper CreatePlayerHelper();
    }

    public class PlayerHelperFactory : IPlayerHelperFactory
    {
        public IPlayerHelper CreatePlayerHelper()
        {
            return new PlayerHelper();
        }
    }
}
