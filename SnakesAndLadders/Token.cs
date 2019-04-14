using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{

    public class Token
    {
        public ISquare Square { get; set; }
    }

    public interface ITokenFactory
    {
        Token GetToken();
    }

    public class TokenFactory : ITokenFactory
    {
        public Token GetToken()
        {
            return new Token();
        }
    }
}
