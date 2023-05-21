using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class snakeBody : Slot
    {
        private bool _isHead;
        private int _type;
        private int _direction;
        private int _x;
        private int _y;

        public snakeBody(bool isHead, int type, int direction, int x, int y)
        {
            _isHead = isHead;
            _type = type;
            _direction = direction;
            _x = x;
            _y = y;
            if (_isHead)
            {
                switch (_type)
                {
                    case 0:
                        _image.BackgroundImage = Snake.Properties.Resources.snake0Head;
                        break;
                    case 1:
                        //_image.BackgroundImage = Snake.Properties.Resources.snake1Head;
                        break;
                    case 2:
                        //_image.BackgroundImage = Snake.Properties.Resources.snake2Head;
                        break;
                }
                _image.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                switch (_type)
                {
                    case 0:
                        _image.BackgroundImage = Snake.Properties.Resources.snake0Body;
                        break;
                    case 1:
                        //_image.BackgroundImage = Snake.Properties.Resources.snake1Body;
                        break;
                    case 2:
                        //_image.BackgroundImage = Snake.Properties.Resources.snake2Body;
                        break;
                }
                _image.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        
        public bool getHead()
        { 
            return _isHead;
        }

        public int getType()
        {
            return _type;
        }

        public void setDirection(int direction)
        {
            _direction = direction;
        }

        public int getDirection()
        {
            return _direction;
        }

        public int getX()
        {
            return _x;
        }

        public int getY()
        {
            return _y;
        }

        public void setX(int x)
        {
            _x = x;
        }

        public void setY(int y)
        {
            _y = y;
        }
    }
}