using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lime
{
    class SpriteRender : Component
    {
        private Sprite _sprite;
        public Sprite Sprite
        {
            get
            {
                return this._sprite;
            }
            set
            {
                this._sprite = value;
            }
        }

        private float _fps;
        public float FPS
        {
            get
            {
                return this._fps;
            }
            set
            {
                this._fps = value;
            }
        }

        private int _layer;
        public int Layer
        {
            get
            {
                return this._layer;
            }
            set
            {
                this._layer = value;
            }
        }

        pri
    }
}
