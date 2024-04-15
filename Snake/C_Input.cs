using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{

    public static class C_Input
    {
        private static HashSet<Keys> pressedKeys = new HashSet<Keys>();

        public static bool KeyPressed(Keys key)
        {
            return pressedKeys.Contains(key);
        }

        public static void KeyDown(Keys key)
        {
            pressedKeys.Add(key);
        }

        public static void KeyUp(Keys key)
        {
            pressedKeys.Remove(key);
        }
    }
}
