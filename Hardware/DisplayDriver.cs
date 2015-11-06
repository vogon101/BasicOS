using Cosmos.HAL;
using Sys = Cosmos.System;
namespace Display
{
    public class DisplayDriver
    {

        protected VGAScreen screen;
        private int width, height = 0;

        public DisplayDriver()
        {
            screen = new VGAScreen();
            screen.SetGraphicsMode(VGAScreen.ScreenSize.Size320x200, VGAScreen.ColorDepth.BitDepth8);
            clear(0);
            width = screen.PixelWidth;
            height = screen.PixelHeight;
        }

        public virtual void init() { }

        public virtual void setPixel (int x, int y, int c)
        {
            if (screen.GetPixel320x200x8((uint)x, (uint)y) != (uint)c)
                setPixelRaw(x, y, c);
        }

        public virtual byte getPixel (int x, int y)
        {
            return (byte)screen.GetPixel320x200x8((uint)x, (uint)y);
        }

        public virtual void clear ()
        {
            clear(0);
        }

        public virtual void clear (int c)
        {
            //screen.Clear(c);
            for (int x = 0; x < getWidth(); x++)
            {
                for (int y = 0; y < getHeight(); y++)
                {
                    if (getPixel(x,y) != (byte)c)
                    {
                        setPixelRaw(x, y, c);
                    }
                }
            }
        }

        public virtual void step() { }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public void setPixelRaw (int x, int y, int c)
        {

            screen.SetPixel320x200x8((uint)x, (uint)y, (uint)c);

        }

        public virtual void fillArea (int startX, int startY, int endX, int endY, int colour)
        {

            if (startX > endX)
                throw new System.Exception("startX is greater than endX");

            if (startY > endY)
                throw new System.Exception("startX is greater than endX");

            int x = startX;
            int y = startY;
            while (x != endX)
            {
                while (y != endY)
                {
                    setPixel(x, y, colour);
                    y++;
                }
                x++;
                y = startY;
            }
        }

    }
}
