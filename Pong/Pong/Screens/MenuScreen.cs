using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Screens
{
    abstract class MenuScreen : BaseScreen, IScreen
    {
        //private const float ANIMATION_SPEED = 100;

        float offset = 2f;
        protected TimeSpan TransitionOnTime;
        protected TimeSpan TransitionOffTime;
        protected bool SideMenu;
        protected float TransitionAlpha;
        protected float TransitionPosition;
        protected int selectedEntry = 0;
        private string menuTitle;
        protected SpriteFont font;

        private List<MenuEntry> menuEntries = new List<MenuEntry>();
        protected IList<MenuEntry> MenuEntries
        {
            get { return menuEntries; }
        }

        private float SidebarOffset
        {
            get
            {
                menuEntries.OrderByDescending(m => m.StringWidth);
                return menuEntries[0].StringWidth;
            }
        }

        // Main constructor
        public MenuScreen(Game parent, string menuTitle)
            : base(parent)
        {
            this.menuTitle = menuTitle;

            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
            font = LoadFont("scorefont");
        }

        // Controlls movement across menus
        public virtual void HandleInput()
        {
            if (Input.Clicked(Keys.Up))
            {
                selectedEntry--;

                if (selectedEntry < 0)
                    selectedEntry = menuEntries.Count - 1;
            }

            if (Input.Clicked(Keys.Down))
            {
                selectedEntry++;

                if (selectedEntry >= menuEntries.Count)
                    selectedEntry = 0;
            }

            if (Input.Clicked(Keys.Enter))
            {
                PerformSelectedAction(selectedEntry);
            }

            if (Input.Clicked(Keys.Escape))
            {
                ExitOnEscape();
            }
        }

        // Handles exceptions if current menuEntry is invalid
        protected virtual void PerformSelectedAction(int entryIndex)
        {
            try
            {
                menuEntries[entryIndex].Action();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Failed to perform action:");
                Console.WriteLine(ex.Message);
            }
        }

        protected virtual void ExitOnEscape()
        {

        }


        private void AnimateMenuEntry()
        {
            //float transitionOffset = (float)Math.Pow(TransitionPosition, offset);

            //Vector2 position = new Vector2(0f, 400);

            //for (int index = 0; index < menuEntries.Count; index++)
            //{
            //    MenuEntry menuEntry = menuEntries[index];

            //    if (SideMenu)
            //        position.X = camera.Viewport.Width / 2 + SidebarOffset;
            //    else
            //        position.X = camera.Viewport.Width / 2 - menuEntry.Getwidth(this) / 2;

            //    if (ScreenState == ScreenState.TransitionOn)
            //        position.X -= transitionOffset * ANIMATION_SPEED;
            //    else
            //        position.X += transitionOffset * 100;

            //    menuEntry.Position = position;

            //    position.Y += menuEntry.GetHeight(this);
            //}
        }

        public virtual void Update(float delta)
        {
            for (int index = 0; index < menuEntries.Count; index++)
            {
                bool isSelected = index == selectedEntry;

                menuEntries[index].Update(delta);
            }
        }

        public virtual void Draw()
        {
            AnimateMenuEntry();

            batch.Begin();

            for (int index = 0; index < menuEntries.Count; index++)
            {
                MenuEntry menuEntry = menuEntries[index];

                bool isSelected = (index == selectedEntry);

                menuEntry.Draw(batch);
                float sidebarOffset = menuEntry.StringWidth;
            }

            float transitionOffset = (float)Math.Pow(TransitionPosition, offset);
            Vector2 titlePosition = new Vector2(camera.Viewport.Width / 2, camera.Viewport.Height / 2 / 2);
            if (SideMenu)
                titlePosition.X = SidebarOffset + camera.Viewport.Width / 2;

            Vector2 titleOrigin = font.MeasureString(menuTitle) / 2;
            Color titleColor = new Color(192, 192, 192) * TransitionAlpha;
            float titleScale = 1.25f;

            titlePosition.Y -= transitionOffset * 500;

            batch.DrawString(font, menuTitle, titlePosition, titleColor, 0, titleOrigin, titleScale, SpriteEffects.None, 0);

            batch.End();
        }

        public void Dispose()
        {
            content.Dispose();
            batch.Dispose();
        }
    }
}
