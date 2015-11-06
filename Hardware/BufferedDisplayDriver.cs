using Sys = Cosmos.System;

namespace Display
{
    public class BufferedDisplayDriver: DisplayDriver
    {
        byte[] buffer = new byte[320*200];
        public bool didChange = false;


        public BufferedDisplayDriver():base()
        {
        }

        public override void init()
        {
        }

        override public void setPixel(int x, int y, int c)
        {
            if (getPixel(x, y) != (byte)c)
            {
                buffer[x + (y * getWidth())] = (byte)c;
                didChange = true;
            }
        }

        public override byte getPixel(int x, int y)
        {
            return buffer[x+(y*320)];
        }

        public byte getPixelReal(int x, int y)
        {
            return base.getPixel(x, y);
        }

        public override void clear(int c)
        {
            for (int x = 0; x < getWidth(); x++)
            {
                for (int y=0; y< getHeight(); y++)
                {
                    if (buffer[x + (y * getWidth())] != (byte)c)
                    {
                        buffer[x + (y * getWidth())] = (byte)c;
                    }
                }
            }
        }

        public void clearReal (int c)
        {
            base.clear(c);
        }

        public void reDraw()
        {
            if (didChange)
            {
                for (int x = 0; x < getWidth(); x++)
                {
                    for (int y = 0; y < getHeight(); y++)
                    {
                        base.setPixel(x, y, buffer[x + (y * getWidth())]);
                    }
                }
            }
        }

        public override void step()
        {
            reDraw();
            clear(0);
        }

    }
}
