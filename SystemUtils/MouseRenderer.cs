using Cosmos;
using Cosmos.Core.Plugs;
using Input;
using Sys = Cosmos.System;

namespace Display
{
    public class MouseRenderer
    {

        private MouseDriver mouse;
        private DisplayDriver display;
        private int color;

        public MouseRenderer(MouseDriver m, DisplayDriver d, int c=2) {
            mouse = m;
            display = d;
            color = c;
        }

        public virtual void renderMouse ()
        {
            int X = mouse.X();
            int Y = mouse.Y();
            display.setPixel(X, Y, 40);
            display.setPixel(X + 1, Y, 40);
            display.setPixel(X + 2, Y, 40);
            display.setPixel(X, Y + 1, 40);
            display.setPixel(X, Y + 2, 40);
            display.setPixel(X + 1, Y + 1, 40);
            display.setPixel(X + 2, Y + 2, 40);
            display.setPixel(X + 3, Y + 3, 40);
        }

    }
}
