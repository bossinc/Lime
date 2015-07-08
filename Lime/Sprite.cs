using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Lime
{
    public class Sprite
    {
        private Texture2D _texture2D;
        public Texture2D Texture2D
        {
            get
            {
                return this._texture2D;
            }
            set
            {
                this._texture2D = value;
            }
        }

        public Sprite()
        {
        }
    }
}
