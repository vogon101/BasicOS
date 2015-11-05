using Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class Desktop
    {

        protected DisplayDriver display;

        public Desktop (DisplayDriver d)
        {
            display = d;
        }

        public abstract void step();

        public abstract void onClick();

        public abstract void render();

    }
}
