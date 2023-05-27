namespace Snake
{
    [Serializable]
    internal class Player
    {
        private string _playerName;
        private int _playerScore;
        private int _snakeType;
        private string _playerInput;
        private List<snakeBody> _coordinates;
        private bool _status;
        private bool _locked;


        public Player(string playerName, string playerInput, int snakeType = 0, int playerScore = 0, bool status = false)
        {
            _playerName = playerName;
            _playerScore = playerScore;
            _snakeType = snakeType;
            _playerInput = playerInput;
            _coordinates = new List<snakeBody>();
            _status = status;
            _locked = false;
        }

        public int getScore()
        {
            return _playerScore;
        }
        public string getInput()
        {
            return _playerInput;
        }

        public string getPlayerName()
        {
            return _playerName;
        }

        public int getPlayerType()
        {
            return _snakeType;
        }

        public bool isLocked()
        {
            return _locked;
        }

        public List<snakeBody> getCoordinates()
        {
            return _coordinates;
        }

        public bool isAlive()
        {
            return _status;
        }

        public void setStatus(bool status)
        {
            _status = status;
        }

        public bool getStatus()
        {
            return _status;
        }

        public void setLocked(bool locked)
        {
            _locked = locked;
        }

        public void setPlayerName(string playerName)
        {
            _playerName = playerName;
        }

        public void updateScore(int score)
        {
            _playerScore += score;
        }
    }
}