using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.HAL;
namespace Input
{
    public class MouseDriver
    {

        public Mouse mouse;

        public MouseDriver(int width, int height)
        {
            mouse = new Mouse();
            mouse.Initialize((uint)height, (uint)width);
        }

        public int X()
        {
            return mouse.X;
        }

        public int Y()
        {
            return mouse.Y;
        }

        public Mouse.MouseState getButton ()
        {
            return mouse.Buttons;
        }

        public bool isLeftClicked ()
        {
            return (getButton() == Mouse.MouseState.Left);
        }

        public bool isRightClicked ()
        {
            return (getButton() == Mouse.MouseState.Right);
        }

        public bool isMiddleClicked ()
        {
            return (getButton() == Mouse.MouseState.Middle);
        }

        public bool isAnyClicked ()
        {
            return !(getButton() == Mouse.MouseState.None);
        }

        public void setX(int x)
        {
            mouse.X = x;
        }

        public void setY(int y)
        {
            mouse.Y = y;
        }

    }
}
