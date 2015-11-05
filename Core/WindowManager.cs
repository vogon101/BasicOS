using Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemUtils;

namespace Core
{
    public class WindowManager
    {

        public DisplayDriver display;
        public Desktop desktop;
        public FontRenderer fontRenderer;

        public List<Window> windows;

        public WindowManager (DisplayDriver dd, Desktop desk, FontRenderer fr)
        {
            display = dd;
            desktop = desk;
            fontRenderer = fr;

            windows = new List<Window>(0);
        }

        //TODO: Return bool from step for fails
        public void step ()
        {

            try {
                desktop.step();
                desktop.render();
            }
            catch (NullReferenceException e){}

            foreach (Window w in windows) {
                w.step();
            }

            //TODO: Order the windows
            foreach (Window w  in windows)
            {
                w.render();
            }
        }

        public void onClick()
        {

        }
    }
}
