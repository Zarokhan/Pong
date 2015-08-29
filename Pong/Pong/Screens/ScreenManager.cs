using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pong.Screens;

namespace Pong.Screens
{
    class ScreenManager
    {
        private Game parent;
        private IScreen currentScreen;
        
        public ScreenManager(Game parent)
        {
            this.parent = parent;
        }

        public void SetScreen(IScreen screen)
        {
            if (currentScreen != null)
                currentScreen.Dispose();

            currentScreen = screen;
        }

        public void Update(float delta)
        {
            if (currentScreen != null)
                currentScreen.Update(delta);
        }

        public void Draw()
        {
            if (currentScreen != null)
                currentScreen.Draw();
        }
    }
}
