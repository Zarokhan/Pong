using Pong.Gameworld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Screens.MenuSystem.Menus
{
    class MainMenuScreen : MenuScreen
    {
        MenuEntry play, exit;

        public MainMenuScreen(Game parent, string title)
            : base (parent, title)
        {
            play = new MenuEntry("Play vs AI", font);
            exit = new MenuEntry("Exit", font);

            play.Selected += Play;
            exit.Selected += Exit;

            MenuEntries.Add(play);
            MenuEntries.Add(exit);
        }

        private void Play(object sender, EventArgs e)
        {
            Game.screenMngr.SetScreen(new GameScreen(parent, GameMode.AI));
        }

        private void Exit(object sender, EventArgs e)
        {
            parent.Exit();
        }

    }
}
