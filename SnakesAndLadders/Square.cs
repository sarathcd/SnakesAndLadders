using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{
    public interface ISquare
    {
        int Id { get; set; }
        void AddToken(Token token);
        void RemoveToken(Token token);

        bool ContainsToken(Token token);
    }

    public class Square : ISquare
    {
        public int Id { get; set; }

        private List<Token> _tokens;

        public Square()
        {
            this._tokens = new List<Token>();
        }

        public void AddToken(Token token)
        {
            if (!this._tokens.Contains(token))
                this._tokens.Add(token);
        }

        public void RemoveToken(Token token)
        {
            if (this._tokens.Contains(token))
                this._tokens.Remove(token);
        }

        public bool ContainsToken(Token token)
        {
            return this._tokens.Contains(token);
        }
    }

    public interface ISquareFactory
    {
        int NoOfSquares { get; set; }
        List<ISquare> GetSquares();
    }

    public class SquareFactory : ISquareFactory
    {
        public int NoOfSquares { get; set; }

        public SquareFactory()
        {
            this.NoOfSquares = 100;
        }
        public List<ISquare> GetSquares()
        {
            var squares = new List<ISquare>();
            for (int i = 1; i <= this.NoOfSquares; i++)
                squares.Add(new Square { Id = i });

            return squares;
        }
    }

}
