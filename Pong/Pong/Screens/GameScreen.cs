﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Gameworld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pong.Utilities;

namespace Pong.Screens
{
    class GameScreen : BaseScreen, IScreen
    {
        // Global variables
        private World world;

        // Constructor
        public GameScreen(Game parent, GameMode mode) 
            : base(parent)
        {
            world = new World(this, mode);
        }

        // Update loop
        public void Update(float delta)
        {
            camera.Update(delta);
            world.Update(delta);
        }

        // Render loop
        public void Draw()
        {
            batch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, camera.Transform);
            world.Draw(batch);
            batch.End();
        }

        // Dispose method
        public void Dispose()
        {
            content.Dispose();
            batch.Dispose();
        }

        // Getters

        public ContentManager GetContent()
        {
            return content;
        }

        Texture2D IScreen.LoadTexture(string filepath)
        {
            return content.Load<Texture2D>("Graphics/" + filepath);
        }

        public Camera GetCamera()
        {
            return camera;
        }

        public SpriteFont LoadFont(string filepath)
        {
            return content.Load<SpriteFont>("Fonts/" + filepath);
        }
    }
}
