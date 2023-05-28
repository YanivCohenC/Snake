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

        public Player(exportPlayer p)
        {
            _playerName = p.getName();
            _playerScore = p.getScore();
            _snakeType = p.getType();
            _playerInput = p.getInput();
            _status = p.getStatus();
            _coordinates = new List<snakeBody>();
            for (int i = 0; i < p.getCoordinates().Count; i++)
            {
                if (i == 0)
                    _coordinates.Add(new snakeBody(true, p.getType(), p.getDirection()[i], p.getCoordinates()[i].First().Key, p.getCoordinates()[i].First().Value, p.getStatus()));
                else
                    _coordinates.Add(new snakeBody(false, p.getType(), p.getDirection()[i], p.getCoordinates()[i].First().Key, p.getCoordinates()[i].First().Value, p.getStatus()));
            }
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