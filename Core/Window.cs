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
        protected WindowManager windowManager;

        //TODO: Protect the display
        public Window (WindowManager wm)
        {
            startX = wm.sX;
            startY = wm.sY;
            endX = wm.eX;
            endY = wm.eY;

            windowManager = wm;
            renderer = new WindowRenderer(this, wm);

        }

        public abstract void render();

        public abstract void step();

        public abstract void onClose();

    }
}
