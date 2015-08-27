using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pong.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Screens
{
    abstract class BaseScreen
    {
        protected Game parent;
        protected SpriteBatch batch;
        protected Camera camera;
        protected ContentManager content;

        protected Texture2D LoadTexture(string Texturepath)
        {
            return content.Load<Texture2D>(Texturepath);
        }

        public BaseScreen(Game parent)
        {
            this.parent = parent;

            content = new ContentManager(parent.Content.ServiceProvider, "Content");
            batch = new SpriteBatch(parent.GraphicsDevice);
            camera = new Camera(new Viewport(0, 0, parent.GraphicsDevice.Viewport.Width, parent.GraphicsDevice.Viewport.Height));
        }
    }
}
