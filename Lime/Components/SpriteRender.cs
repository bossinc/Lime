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

        private AnimationController _animationController;
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

        private Color _color;
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

        private float _layer;
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

        public SpriteRender()
        {
            GraphicsManager.Instance.AddSpriteRender(this);
            this.Color = Color.White;
        }

        public void Update(GameTime gameTime)
        {
            if (this.AnimationController != null)
            {
                this.AnimationController.AdvanceToNextFrame();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Point drawSize = new Point(this.AnimationController.GetCurrentFrame().Width, this.AnimationController.GetCurrentFrame().Height);
            Point centerOffset = new Point(drawSize.X / 2, drawSize.Y / 2);
            Rectangle drawPosition = new Rectangle(this.GameObject.Transform.Position.ToPoint() - centerOffset, drawSize);
            spriteBatch.Draw(Sprite.Texture2D, drawPosition, this.AnimationController.GetCurrentFrame(), this.Color, this.GameObject.Transform.Rotation, this.GameObject.Transform.Position, SpriteEffects.None, this.Layer);
        }
    }
}
