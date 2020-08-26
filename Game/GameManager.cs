namespace EXCell
{
    public class GameManager : IGameManager
    {
        public GameManager()
        {
        }
        private Game CurrentGame { get; set; }

        public int WinCount { get; set; }
        
        public void Start(Game game)
        {
            CurrentGame = game;
            CurrentGame.StartGame(this);
        }
    }
}