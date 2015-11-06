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

        public int sX, sY, eX, eY = 0;

        private Window[] backGroundWindows;

        private Window topWindow = null;

        public WindowManager (DisplayDriver dd, Desktop desk, FontRenderer fr)
        {
            display = dd;
            desktop = desk;
            fontRenderer = fr;

            sX = 10;
            sY = 10;
            eX = display.getWidth() - 10;
            eY = display.getHeight() - 10;

            backGroundWindows = new Window[0];
        }

        /*
            Codes:  
                 0 = Success
                 1 = Fail
                 2 = Shutdown
                 3 = Restart
        */
        public int step ()
        {

            if (desktop != null)
                desktop.step();
            Cosmos.System.Kernel.PrintDebug("After desktop step");

            for (int i = 0; i < backGroundWindows.Count(); i++)
                backGroundWindows.ElementAt(i).step();
            Cosmos.System.Kernel.PrintDebug("After bgWindow step");

            if (topWindow != null)
            {
                topWindow.step();
                Cosmos.System.Kernel.PrintDebug("After topwindow step");
                topWindow.render();
                Cosmos.System.Kernel.PrintDebug("After topwindow render");
            }
            else
                if (desktop != null)
                    desktop.render();

            Cosmos.System.Kernel.PrintDebug("Done");
            return 0;
               
        }

        public void onClick()
        {

        }

        public void addWindow (Window w)
        {
            if (topWindow != null)
            {
                var temp = new Window[backGroundWindows.Length + 1];
                backGroundWindows.CopyTo(temp, 0);
                temp[backGroundWindows.Length] = w;
                backGroundWindows = temp;
            }
            topWindow = w;
        }
    }
}
