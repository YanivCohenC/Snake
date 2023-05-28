using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    [Serializable]
    internal class exportPlayer
    {
        private string _playerName;
        private int _playerScore;
        private int _snakeType;
        private string _playerInput;
        private List<Dictionary<int, int>> _coordinates;
        private bool _status;
        private List<Direction> _direction;

        public exportPlayer(Player p)
        {
            _playerName = p.getPlayerName();
            _playerScore = p.getScore();
            _snakeType = p.getPlayerType();
            _playerInput = p.getInput();
            _coordinates = new List<Dictionary<int, int>>();
            _direction = new List<Direction>();
            for (int i = 0; i< p.getCoordinates().Count; i++)
            {
                _coordinates.Add(new Dictionary<int, int>() { { p.getCoordinates()[i].getX(), p.getCoordinates()[i].getY() } });
                _direction.Add(p.getCoordinates()[i].getDirection());
            }
            _status = p.getStatus();
        }

        public string getName()
        {
            return _playerName;
        }

        public int getScore()
        {
            return _playerScore;
        }

        public int getType()
        {
            return _snakeType;
        }

        public string getInput()
        {
            return _playerInput;
        }

        public List<Dictionary<int, int>> getCoordinates()
        {
            return _coordinates;
        }

        public bool getStatus()
        {
            return _status;
        }

        public List<Direction> getDirection()
        {
            return _direction;
        }
    }
}