namespace Snake
{
    internal class Player
    {
        private string _playerName;
        private int _playerScore;
        private int _snakeType;
        private string _playerInput;
        private List<snakeBody> _coordinates;



        public Player(string playerName, string playerInput, int snakeType = 0, int playerScore = 0)
        {
            _playerName = playerName;
            _playerScore = playerScore;
            _snakeType = snakeType;
            _playerInput = playerInput;
            _coordinates = new List<snakeBody>();
        }

        public string getPlayerName()
        {
            return _playerName;
        }

        public int getPlayerType()
        {
            return _snakeType;
        }

        public List<snakeBody> getCoordinates()
        {
            return _coordinates;
        }
    }
}