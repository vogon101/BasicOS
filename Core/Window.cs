using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class Window
    {

        public int startX, startY, endX, endY;

        public string title = "Window";

        protected WindowRenderer renderer;

        //TODO: Protect the display
        public Window (int sX, int sY, int eX, int eY, WindowManager wm)
        {
            startX = sX;
            startY = sY;
            endX = eX;
            endY = eY;

            renderer = new WindowRenderer(this, wm);

        }

        public abstract void render();

        public abstract void step();

        public abstract void onClose();

    }
}
