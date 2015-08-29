using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Utilities
{
    class Camera
    {
        protected float _zoom; //Camera Zoom Value

        protected Matrix _transform; //Camera Transform Matrix

        protected Matrix _inverseTransform; //Inverse of Transform Matrix

        protected Vector2 _pos; //Camera Position

        protected float _rotation; //Camera Rotation Value (Radians)

        protected Viewport _viewport; //Cameras Viewport

        protected MouseState _mState; //Mouse state

        protected KeyboardState _keyState; //Keyboard state

        protected Int32 _scroll; //Previous Mouse Scroll Wheel Value

        public float Zoom

        {

            get { return _zoom; }

            set { _zoom = value; }

        }

        public Camera(Viewport viewport)

        {

            _zoom = 1.0f;

            _scroll = 1;

            _rotation = 0.0f;

            _pos = new Vector2(0, 0);

            _viewport = viewport;

        }


        /// <summary>

        /// Camera View Matrix Property

        /// </summary>

        public Matrix Transform

        {

            get { return _transform; }

            set { _transform = value; }

        }

        /// <summary>

        /// Inverse of the view matrix, can be used to get objects screen coordinates

        /// from its object coordinates

        /// </summary>

        public Matrix InverseTransform

        {

            get { return _inverseTransform; }

        }

        public Vector2 Pos

        {

            get { return _pos; }

            set { _pos = value; }

        }

        public float Rotation

        {

            get { return _rotation; }

            set { _rotation = value; }

        }

        public Viewport Viewport
        {
            get { return _viewport; }
        }

        public void Update(float delta)
        {

            //Call Camera Input

            //Input();

            //Clamp zoom value

            MathHelper.Clamp(_zoom, 0.01f, 10.0f);

            //Clamp rotation value

            //_rotation = ClampAngle(_rotation);

            //Create view matrix

            _transform = Matrix.CreateRotationZ(_rotation) *

                            Matrix.CreateScale(new Vector3(_zoom, _zoom, 1)) *

                            Matrix.CreateTranslation(_viewport.Width * 0.5f - _pos.X, _viewport.Height * 0.5f - _pos.Y, 0);

            //Update inverse matrix

            _inverseTransform = Matrix.Invert(_transform);

        }

    }
}

