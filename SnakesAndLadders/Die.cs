using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{
    public interface IDie
    {
        int Roll();
    }

    public class Die : IDie
    {
        public int Roll()
        {
            var rnd = new Random();
            return rnd.Next(1, 7);
        }
    }

    public interface IDieFactory
    {
        IDie CreateDie();
    }

    public class DieFactory : IDieFactory
    {
        public IDie CreateDie()
        {
            return new Die();
        }
    }
}
