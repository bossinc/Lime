using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lime.Animation
{
    public class SpriteRender : Component
    {
        /// <summary>
        /// The spritesheet to be used to rendered
        /// </summary>
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
        private Sprite _sprite;

        /// <summary>
        /// Controls the which sprites on the spritesheet are displayed
        /// </summary>
        public AnimationController AnimationController
        {
            get
            {
                return this._animationController;
            }
            set
            {
                this._animationController = value;
            }
        }
        private AnimationController _animationController;

        /// <summary>
        /// The base color of the sprite
        /// </summary>
        public Color Color
        {
            get
            {
                return this._color;
            }
            set
            {
                this._color = value;
            }
        }
        private Color _color;

        /// <summary>
        /// The draw layer that the sprite appears on. Decending order.
        /// </summary>
        public float Layer
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
        private float _layer;

        public SpriteRender()
        {
            this.Color = Color.White;
        }
        
        /// <summary>
        /// DO NOT USE THIS FUNCTION!
        /// It must be public because it inherits componet
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (this.AnimationController != null)
            {
                this.AnimationController.Update(gameTime);
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            Point drawSize = new Point(this.AnimationController.GetCurrentFrame().Width, this.AnimationController.GetCurrentFrame().Height);
            Vector2 centerOffset = new Vector2(drawSize.X / 2, drawSize.Y / 2);
            Vector2 drawPosition = this.GameObject.Transform.Position;
            spriteBatch.Draw(Sprite.SpriteSheet,
                drawPosition, 
                this.AnimationController.GetCurrentFrame(), 
                this.Color, 
                this.GameObject.Transform.Rotation,
                centerOffset, 
                this.GameObject.Transform.Scale,
                SpriteEffects.None, 
                this.Layer);
        }
    }
}
