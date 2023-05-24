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
        private Direction _direction;
        private int _x;
        private int _y;
        private bool _status;

        public snakeBody(bool isHead, int type, Direction direction, int x, int y, bool status)
        {
            _isHead = isHead;
            _type = type;
            _direction = direction;
            _x = x;
            _y = y;
            _status = status;
            if (_isHead)
            {
                switch (_type)
                {
                    case 0:
                        if (status == true)
                            _image.BackgroundImage = Snake.Properties.Resources.snake0Head;
                        else
                            _image.BackgroundImage = Snake.Properties.Resources.head0Dead;
                        break;
                    case 1:
                        if (status == true)
                            _image.BackgroundImage = Snake.Properties.Resources.snake1Head;
                        else
                            _image.BackgroundImage = Snake.Properties.Resources.head1Dead;
                        break;
                    case 2:
                        if (status == true)
                            _image.BackgroundImage = Snake.Properties.Resources.snake2Head;
                        else
                            _image.BackgroundImage = Snake.Properties.Resources.head2Dead;
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
                        _image.BackgroundImage = Snake.Properties.Resources.snake1Body;
                        break;
                    case 2:
                        _image.BackgroundImage = Snake.Properties.Resources.snake2Body;
                        break;
                }
                _image.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        public snakeBody(snakeBody s)
        {
            _isHead = s._isHead;
            _type = s._type;
            _direction = s._direction;
            _x = s._x;
            _y = s._y;
            _status = s._status;
        }

        public bool getHead()
        { 
            return _isHead;
        }

        public int getType()
        {
            return _type;
        }

        public void setDirection(Direction direction)
        {
            _direction = direction;
        }

        public Direction getDirection()
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