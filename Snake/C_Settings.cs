using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum Direction { Left, Right, Up, Down }

    internal class C_Settings
    {
        private int _width;
        private int _height;
        private int _speed;
        private int _score;
        private int _points;
        private bool _gameOver;
        private Direction _direction;

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public bool GameOver
        {
            get { return _gameOver; }
            set { _gameOver = value; }
        }

        public Direction Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public C_Settings()
        {
            _width = 20;
            _height = 20;
            _speed = 10;
            _score = 0;
            _points = 50;
            _gameOver = false;
            _direction = Direction.Down;
        }

        public void Reset()
        {
            _score = 0;
            _gameOver = false;
            _direction = Direction.Down;
        }
    }
}
