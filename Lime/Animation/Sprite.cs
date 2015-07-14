using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Lime.Animation
{
    public class Sprite
    {
        /// <summary>
        /// A spriteSheet
        /// </summary>
        public Texture2D SpriteSheet
        {
            get
            {
                return this._spriteSheet;
            }
            set
            {
                this._spriteSheet = value;
            }
        }
        private Texture2D _spriteSheet;

        public Sprite(Texture2D spriteSheet)
        {
            this.SpriteSheet = spriteSheet;
        }
    }
}
