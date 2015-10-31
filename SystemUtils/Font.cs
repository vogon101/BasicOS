using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUtils
{
    public abstract class Font
    {

        public int fontSize=5;

        public abstract int[] getChar(char c);

    }
}
