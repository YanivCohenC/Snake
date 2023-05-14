namespace Snake
{
    internal class Player : Menu
    {
        private string _playerName;
        private int _playerScore;
        private int _snakeType;
        private string _playerInput;

        Player(string playerName, string playerInput, int snakeType = 0, int playerScore = 0)
        {
            _playerName = playerName;
            _playerScore = playerScore;
            _snakeType = snakeType;
            _playerInput = playerInput;
        }
    }
}