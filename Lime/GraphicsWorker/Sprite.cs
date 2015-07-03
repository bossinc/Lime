using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lime
{
    class Sprite
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

        private List<Animation> Animations;


    }
}
