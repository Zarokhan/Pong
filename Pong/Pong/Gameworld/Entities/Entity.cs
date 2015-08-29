using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Gameworld.Entities
{
    abstract class Entity : IEntitiy
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected float xVel, yVel;
        protected Vector2 origin;
        protected Vector2 scale;
        protected int width, height;
        protected float rotation;
        protected Color color;
        protected Rectangle srcRec;
        protected Rectangle hitbox;

        public Entity(Texture2D texture, int width, int height)
        {
            this.texture = texture;
            this.width = width;
            this.height = height;
            position = new Vector2(0, 0);
            color = Color.White;
            srcRec = new Rectangle(0, 0, texture.Width, texture.Height);
            origin = new Vector2(width * 0.5f, height * 0.5f);
            scale = new Vector2(1, 1);
            hitbox = new Rectangle((int)(position.X - width * 0.5f), (int)(position.Y - height * 0.5f), width, height);
        }

        public virtual void Update(float delta)
        {
            hitbox.X = (int)(position.X - width * 0.5f);
            hitbox.Y = (int)(position.Y - height * 0.5f);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, position, srcRec, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }

        public abstract void Reset();

        public Rectangle Hitbox
        {
            get { return hitbox; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Origin
        {
            get { return origin; }
        }

        public float XVelocity
        {
            get { return xVel; }
            set { xVel = value; }
        }

        public float YVelocity
        {
            get { return yVel; }
            set { yVel = value; }
        }
    }
}
