using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Pong.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pong.Gameworld;

namespace Pong.Screens
{
    class MainMenu : BaseScreen, IScreen
    {
        string[] items = {
            "Play",
            "Exit"
        };
        int selected;
        SpriteFont font;

        public MainMenu(Game parent)
            : base(parent)
        {
            selected = 0;
            font = LoadFont("scorefont");
        }

        public void Update(float delta)
        {
            camera.Update(delta);

            if (Input.Clicked(Keys.Down))
            {
                selected++;

                if (selected >= items.Length)
                    selected = 0;
            }
            else if (Input.Clicked(Keys.Up))
            {
                selected--;

                if (selected < 0)
                    selected = items.Length - 1;
            }

            if (Input.Clicked(Keys.Enter))
            {
                switch (selected)
                {
                    case 0:
                        Game.screenMngr.SetScreen(new GameScreen(parent, GameMode.Versus));
                        break;
                    case 1:
                        parent.Exit();
                        break;
                }
            }
        }

        public void Draw()
        {
            batch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

            for (int i = 0; i < items.Length; ++i)
            {
                Color color = (i == selected) ? Color.Red : Color.White;

                batch.DrawString(font, items[i], new Vector2(0, 0 + i * 50), color);

                color = Color.White;
            }

            batch.End();
        }

        public void Dispose()
        {
            content.Dispose();
            batch.Dispose();
        }

        public Camera GetCamera()
        {
            return camera;
        }

        public SpriteFont LoadFont(string filepath)
        {
            return content.Load<SpriteFont>("Fonts/" + filepath);
        }

        public Texture2D LoadTexture(string filepath)
        {
            return content.Load<Texture2D>("Graphics/" + filepath);
        }
    }
}
