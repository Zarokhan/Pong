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
        //
        // Protected variables
        //
        protected Game parent;
        protected SpriteBatch batch;
        protected Camera camera;
        protected ContentManager content;

        // Constructor
        public BaseScreen(Game parent)
        {
            this.parent = parent;
            content = new ContentManager(parent.Content.ServiceProvider, "Content");
            batch = new SpriteBatch(parent.GraphicsDevice);
            camera = new Camera(new Viewport(0, 0, parent.GraphicsDevice.Viewport.Width, parent.GraphicsDevice.Viewport.Height));
        }
    }
}
