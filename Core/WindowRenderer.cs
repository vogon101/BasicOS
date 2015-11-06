using Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class WindowRenderer
    {

        protected Window window;
        protected WindowManager windowManager;
        protected int bgColour;

        public WindowRenderer (Window w, WindowManager wm, int bg = 0)
        {
            window = w;
            windowManager = wm;
            bgColour = bg;
        }

        public void drawPixel(int x, int y, int c)
        {
            if (x > window.endX - window.startX)
                throw new Exception("Window tried to draw to a pixel out of bounds");
            if (y > window.endY - window.startY)
                throw new Exception("Window tried to draw to a pixel out of bounds");
            windowManager.display.setPixel(x, y, c);
        }

        public void renderString (int x, int y, string text)
        {
            if (x > window.endX - window.startX)
                throw new Exception("Window tried to draw to a pixel out of bounds");
            if (y > window.endY - window.startY)
                throw new Exception("Window tried to draw to a pixel out of bounds");
            windowManager.fontRenderer.renderString(x, y, text);
        }

        public void clear ()
        {
            windowManager.display.fillArea(window.startX, window.startY, window.endX, window.endY, bgColour);
        }

        public void renderEdge ()
        {

        }

    }
}
