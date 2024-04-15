using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class C_Circle : GameObject
    {
        private List<GameObject> _gameObjects;
        private C_Settings _settings;

        public C_Circle(int x, int y) : base(x, y)
        {
            _x = x;
            _y = y;
        }
    }
}
