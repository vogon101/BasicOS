﻿using Sys = Cosmos.System;

namespace Display
{
    public class BufferedDisplayDriver: DisplayDriver
    {
        byte[] buffer = new byte[320*200];
        public bool didChange = false;
        public int changeX, changeY;


        public BufferedDisplayDriver():base()
        {
        }

        override public void setPixel(int x, int y, int c)
        {
            if (getPixel(x, y) != (byte)c)
            {
                buffer[x + (y * 320)] = (byte)c;
                didChange = true;
                if (x>changeX)
                    changeX = x + 1;
                if (y>changeY)
                    changeY = y + 1;
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
                    if (buffer[x + (y * 320)] != (byte)c)
                    {
                        buffer[x + (y * 320)] = (byte)c;
                        changeX = x;
                        changeY = y;
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
                for (int x = 0; x < changeX; x++)
                {
                    for (int y = 0; y < changeY; y++)
                    {
                        base.setPixel(x, y, buffer[x + (y * getWidth())]);
                    }
                }
            }
            changeX = 0;
            changeY = 0;
            clear(0);
        }

        public override void step()
        {
            reDraw();
        }

    }
}
