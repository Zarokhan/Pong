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
        private float _zoom; //Camera Zoom Value
        private Matrix _transform; //Camera Transform Matrix
        private Matrix _inverseTransform; //Inverse of Transform Matrix
        private Vector2 _pos; //Camera Position
        private float _rotation; //Camera Rotation Value (Radians)
        private Viewport _viewport; //Cameras Viewport

        public Camera(Viewport viewport)
        {
            _zoom = 1.0f;
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

        public void Update(float delta)
        {
            //Create view matrix
            _transform = Matrix.CreateRotationZ(_rotation) *
                            Matrix.CreateScale(new Vector3(_zoom, _zoom, 1)) *
                            Matrix.CreateTranslation(_viewport.Width * 0.5f - _pos.X, _viewport.Height * 0.5f - _pos.Y, 0);

            //Update inverse matrix
            _inverseTransform = Matrix.Invert(_transform);
        }

        // Properties

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

        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; }
        }
    }
}

