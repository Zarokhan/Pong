using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Pong.Screens;
using Pong.Utilities;

namespace Pong
{
    class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        public static ScreenManager screenMngr;
        public static Texture2D dot;
        public static Random rnd;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = (int)(1920 * 0.8f);
            graphics.PreferredBackBufferHeight = (int)(1080 * 0.8f);
            graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            rnd = new Random();
            dot = Content.Load<Texture2D>("Graphics/dot");
            screenMngr = new ScreenManager(this);
            screenMngr.SetScreen(new MainMenu(this));
            base.Initialize();
        }

        protected override void LoadContent()
        {
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Input.Update();
            screenMngr.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(50, 50, 50));
            screenMngr.Draw();
            base.Draw(gameTime);
        }
    }
}
