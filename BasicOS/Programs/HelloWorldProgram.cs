using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOS.Programs
{
    class HelloWorldProgram : Window
    {

        public HelloWorldProgram(WindowManager wm) : base(wm) { }

        private int x = 0;

        public override void onClose()
        {
            
        }

        public override void render()
        {
            renderer.drawPixel(x, 10, 2);
            renderer.renderString(10, 40, windowManager.eX.ToString());

        }

        public override void step()
        {
            x++;
        }
    }
}
