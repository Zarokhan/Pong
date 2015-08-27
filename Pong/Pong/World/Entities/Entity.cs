using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Entities
{
    abstract class Entity
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 origin;
        protected Vector2 scale;
        protected int width, height;
        protected float rotation;
        protected Color color;
        protected Rectangle srcRec;

        public Entity(Texture2D texture, int width, int height)
        {
            this.texture = texture;
            this.width = width;
            this.height = height;
            position = new Vector2(0, 0);
            color = Color.White;
            srcRec = new Rectangle(0, 0, texture.Width, texture.Height);
            origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            scale = new Vector2(1, 1);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, position, srcRec, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }
    }
}
