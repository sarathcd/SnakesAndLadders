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

    //public interface ISnakeAndLadderFactory<T>
    //{
    //    List<SnakeOrLadder<T>> GetSnakesAndLadders(List<ISquare<T>> squares);
    //}

    //public class SnakesAndLaddersFactory<T> : ISnakeAndLadderFactory<T>
    //{

    //    public List<SnakeOrLadder<T>> GetSnakesAndLadders(List<ISquare<T>> squares)
    //    {
    //        var snakeOrLadderList = new List<SnakeOrLadder<T>>();
    //        snakeOrLadderList.Add(new SnakeOrLadder<T>
    //        {
    //            LandingSquare = squares.Skip(5).First(),
    //            MoveToSquare = squares.Skip(20).First()
    //        });

    //        //snake
    //        snakeOrLadderList.Add(new SnakeOrLadder<T>
    //        {
    //            LandingSquare = squares.Skip(30).First(),
    //            MoveToSquare = squares.Skip(8).First()
    //        });
    //    }
    //}

    //public class SnakeOrLadder<T>
    //{
    //    public ISquare<T> LandingSquare { get; set; }
    //    public ISquare<T> MoveToSquare { get; set; }
    //}
}
