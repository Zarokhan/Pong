using Microsoft.Xna.Framework.Input;
using Pong.Gameworld;
using Pong.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Screens.MenuSystem.Menus
{
    class MainMenuScreen : MenuScreen
    {
        MenuEntry ai, versus, multiplayer, exit;

        public MainMenuScreen(Game parent, string title)
            : base (parent, title)
        {
            ai = new MenuEntry("vs AI", font);
            versus = new MenuEntry("Versus", font);
            multiplayer = new MenuEntry("Online", font);
            exit = new MenuEntry("Exit", font);

            ai.ClickedEvent += AI;
            versus.ClickedEvent += Versus;
            multiplayer.ClickedEvent += Multiplayer;
            exit.ClickedEvent += Exit;

            menuEntries.Add(ai);
            menuEntries.Add(versus);
            menuEntries.Add(multiplayer);
            menuEntries.Add(exit);
        }

        private void AI(object sender, EventArgs e)
        {
            Game.screenMngr.SetScreen(new GameScreen(parent, GameMode.AI));
        }

        private void Versus(object sender, EventArgs e)
        {
            Game.screenMngr.SetScreen(new GameScreen(parent, GameMode.Versus));
        }

        private void Multiplayer(object sender, EventArgs e)
        {
            Game.screenMngr.SetScreen(new GameScreen(parent, GameMode.Online));
        }

        private void Exit(object sender, EventArgs e)
        {
            parent.Exit();
        }
    }
}
