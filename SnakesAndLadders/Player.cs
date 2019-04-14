using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{
    public interface IPlayer
    {
        void PlayFinished(bool hasPlayerWon);
    }

    public class Player : IPlayer
    {
        public bool HasWon { get; private set; }
        public void PlayFinished(bool hasWon)
        {
            this.HasWon = hasWon;
        }
    }
}
