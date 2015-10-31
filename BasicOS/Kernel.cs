using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.HAL;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using Display;
using SystemUtils;
using BasicOS;
using Input;

namespace MicrOS
{
    public class MicrOS : Sys.Kernel
    {
        protected int mCount = 0;
        public DisplayDriver display;
        public MouseDriver mouse;
        public MouseRenderer mr;

        public MicrOS()
        { 
        }

        protected override void BeforeRun()
        {
            //This function is called before COSMOS starts
            Console.WriteLine("Cosmos booted sucessfully, now starting Kernel");
            display = new BufferedDisplayDriver();
            display.init();

            mouse = new MouseDriver(display.getHeight(), display.getWidth());
            mr = new MouseRenderer(mouse, display, 2);
        }


        protected override void Run()
        {
            Font f = new BasicFont();
            FontRenderer fr = new FontRenderer(display, f);
            int mc = 0;
            while (true) {
                mc++;
                fr.renderString(10, 10, "ABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890 .!?\"'+-=_");
                fr.renderString(10, 20, "X " + mouse.X().ToString());
                fr.renderString(10, 30, "Y " + mouse.Y().ToString());
                fr.renderString(10, 40, mc.ToString());
                fr.renderString(10, 50, "HELLO WORLD\nTHIS IS FREDDIE");
                if (mouse.isLeftClicked())
                {
                    fr.renderString(10, 70, "LEFT BUTTON DOWN");
                }
                if (mouse.isRightClicked())
                {
                    fr.renderString(10, 70, "RIGHT BUTTON DOWN");
                }
                mr.renderMouse();
                fr.renderString(10, 80, "CX " + ((BufferedDisplayDriver)display).changeX.ToString());
                fr.renderString(10, 90, "CY " + ((BufferedDisplayDriver)display).changeY.ToString());
                display.step();
            }
        }
    }
}
