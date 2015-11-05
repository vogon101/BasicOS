using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.HAL;
namespace HardwareInterface
{
    public static class UnixTime
    {

        public static int Hour()
        {
            return RTC.Hour;
        }

        public static int Minute()
        {
            return RTC.Minute;
        }

        public static int Second()
        {
            return RTC.Second;
        }
    }
}
