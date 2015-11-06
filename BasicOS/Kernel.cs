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
using Core;
using BasicOS.Programs;

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
            //Console.WriteLine("Cosmos booted sucessfully, now starting Kernel");
            display = new BufferedDisplayDriver();
            PrintDebug("After display create");
            display.init();
            PrintDebug("After display init");

            mouse = new MouseDriver(display.getHeight(), display.getWidth());
            mr = new MouseRenderer(mouse, display, 2);
        }


        protected override void Run()
        {
            Font f = new BasicFont();
            FontRenderer fr = new FontRenderer(display, f);
            Desktop desktop = null;
            WindowManager windowManager = new WindowManager(display, desktop, fr);
            //windowManager.addWindow(new HelloWorldProgram(windowManager));
            int status = 0;
            while (true) {
                PrintDebug("Before Step");
                status = windowManager.step();
                PrintDebug("After Step");
                mr.renderMouse();
                display.step();
                
            }
        }
    }
}
