using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

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

        public Sprite(ContentManager Content)
        {
            Animations = new List<Animation>();
            _texture2D = Content.Load<Texture2D>("Content/battleBG");
        }

        public Animation GetAnimation(string name)
        {
            foreach (Animation animation in this.Animations)
            {
                if (animation.Name == name)
                {
                    return animation;
                }
            }
            return null;
        }
    }
}
