using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Screens
{
    class MenuEntry
    {
        private string text;
        private Vector2 position;
        SpriteFont font;
        private float selectionFade;



        public bool isSelected;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public event EventHandler<EventArgs> Selected;

        protected internal virtual void Action()
        {
            if (Selected != null)
                Selected(this, new EventArgs());
        }

        public int StringWidth
        {
            get
            {
                if (font != null)
                    return (int)font.MeasureString(text).X;
                else
                    return 0;
            }
        }

        public MenuEntry(MainMenu parent, string text)
        {
            this.text = text;
            this.font = parent.LoadFont("atari full");
        }


        public virtual int Getwidth(MenuScreen screen)
        {

            return (int)font.MeasureString(text).X;
        }

        public virtual int GetHeight(MenuScreen screen)
        {
            return (int)font.LineSpacing;
        }

        public virtual void Update(float delta)
        {
            float fadeSped = delta * 4;
            fadeSped = (isSelected) ? fadeSped : -fadeSped;
            selectionFade = Math.Max(selectionFade + fadeSped, 0);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            Color color = isSelected ? Color.Yellow : Color.White;
            Vector2 origin = new Vector2(0, font.LineSpacing / 2);
            float scale = 1;
            batch.DrawString(font, text, position, color, 0, origin, scale, SpriteEffects.None, 0);
        }
    }
}
