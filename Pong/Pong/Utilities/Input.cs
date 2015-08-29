using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Utilities
{
    public static class Input
    {
        private static KeyboardState KS, oldKS;
        private static MouseState MS, oldMS;
        private static Point mousePoint;
        private static Vector2 mousePosition;

        public static void Update()
        {
            oldKS = KS;
            oldMS = MS;

            mousePoint.X = Mouse.GetState().X;
            mousePoint.Y = Mouse.GetState().Y;
            mousePosition.X = Mouse.GetState().X;
            mousePosition.Y = Mouse.GetState().Y;

            MS = Mouse.GetState();
            KS = Keyboard.GetState();
        }

        public static bool LeftClick()
        {
            return MS.LeftButton == ButtonState.Pressed && oldMS.LeftButton == ButtonState.Released;
        }

        public static bool RightClick()
        {
            return MS.RightButton == ButtonState.Pressed && oldMS.RightButton == ButtonState.Released;
        }

        public static bool Clicked(Keys key)
        {
            return KS.IsKeyDown(key) && oldKS.IsKeyUp(key);
        }

        public static bool Holding(Keys key)
        {
            return KS.IsKeyDown(key);
        }

        public static Point MousePoint()
        {
            return mousePoint;
        }

        public static Vector2 MousePosition()
        {
            return mousePosition;
        }

        public static bool HoldingLeft()
        {
            return MS.LeftButton == ButtonState.Pressed;
        }

        public static bool HoldingRight()
        {
            return MS.RightButton == ButtonState.Pressed;
        }
    }
}
