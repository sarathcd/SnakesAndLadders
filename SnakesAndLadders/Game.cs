using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{
    public class Game
    {
        private ITokenFactory _tokenFactory;
        private IPlayerHelperFactory _playerHelperFactory;
        private IDieFactory _dieFactory;
        private IBoardFactory _boardFactory;

        private IDie _die;
        private IBoard _board;
        private Dictionary<IPlayer, IPlayerHelper> _playerHelpers;
        private bool _isPlayInProgress;

        private Game(IGameFactories gameFactories)
        {
            this._boardFactory = gameFactories.CreateBoardFactory();
            this._tokenFactory = gameFactories.CreateTokenFactory();
            this._playerHelperFactory = gameFactories.CreatePlayerHelperFactory();
            this._dieFactory = gameFactories.CreateDieFactory();
            this._playerHelpers = new Dictionary<IPlayer, IPlayerHelper>();
            this.Reset();
        }

        public static Game CreateGame()
        {
            return new Game(new GameFactories());
        }

        public void AddPlayer(IPlayer player)
        {
            if (this._isPlayInProgress)
                throw new Exception("Play in progress cannot add players.");

            var token = _tokenFactory.GetToken();
            var playerHelper = _playerHelperFactory.CreatePlayerHelper();
            playerHelper.Initialize(this._board, token, this._die);
            this._playerHelpers.Add(player, playerHelper);
        }

        public void Play()
        {
            this._isPlayInProgress = true;

            foreach (var playerHelper in this._playerHelpers.Select(pg => pg.Value))
                playerHelper.PlaceTokenOnBoard();

            var i = 0;
            IPlayer lastPlayer = null;
            IPlayerHelper lastPlayerHelper = null;

            while (true)
            {
                if (i == this._playerHelpers.Count - 1)
                    i = 0;

                lastPlayer = this._playerHelpers.Keys.ElementAt(i);
                lastPlayerHelper = this._playerHelpers.Values.ElementAt(i);

                lastPlayerHelper.Play();
                if (lastPlayerHelper.HasPlayerWon())
                {
                    foreach (var player in this._playerHelpers.Keys.Where(p => p != lastPlayer))
                        player.PlayFinished(false);

                    lastPlayer.PlayFinished(true);
                    break;
                }
            }

            this.Reset();
        }

        public void Reset()
        {
            this._die = this._dieFactory.CreateDie();
            this._board = this._boardFactory.CreateBoard();
        }
    }

    public interface IGameFactories
    {
        IPlayerHelperFactory CreatePlayerHelperFactory();
        IBoardFactory CreateBoardFactory();
        IDieFactory CreateDieFactory();
        ITokenFactory CreateTokenFactory();
    }

    public class GameFactories : IGameFactories
    {
        public IBoardFactory CreateBoardFactory()
        {
            return new BoardFactory(new SquareFactory());
        }

        public IDieFactory CreateDieFactory()
        {
            return new DieFactory();
        }

        public IPlayerHelperFactory CreatePlayerHelperFactory()
        {
            return new PlayerHelperFactory();
        }

        public ITokenFactory CreateTokenFactory()
        {
            return new TokenFactory();
        }
    }
}
