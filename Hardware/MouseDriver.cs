using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.HAL;
namespace Input
{
    public class MouseDriver
    {

        public Mouse mouse;

        public MouseDriver(int width, int height)
        {
            mouse = new Mouse();
            mouse.Initialize((uint)height, (uint)width);
        }

        public int X()
        {
            return mouse.X;
        }

        public int Y()
        {
            return mouse.Y;
        }

    }
}
