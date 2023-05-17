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

        public snakeBody(bool isHead, int type)
        {
            _isHead = isHead;
            _type = type;
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
            }
        }
        
        public bool getHead()
        { 
            return _isHead;
        }
    }
}