﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Lime.Animation
{
    internal sealed class GraphicsManager : Attribute
    {
        private List<SpriteRender> SpriteRenders;

        private ContentManager _content;
        internal ContentManager Content
        {
            get
            {
                return this._content;
            }
            private set
            {
                this._content = value;
            }
        }

        private double updateElapsedTime;
        private double updateIntervalTime;

        public GraphicsManager()
        {
            this.SpriteRenders = new List<SpriteRender>();
            updateIntervalTime = 1 / GameOptions.MAX_DRAW_FPS;
            updateElapsedTime = 0;
        }

        internal void AddSpriteRender(SpriteRender spriteRender)
        {
            this.SpriteRenders.Add(spriteRender);
        }

        internal void DeleteSpriteRender(SpriteRender spriteRender)
        {
            this.SpriteRenders.Remove(spriteRender);
        }

        internal void Update(GameTime gameTime)
        { 
            updateElapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (updateElapsedTime >= updateIntervalTime)
            {
                foreach (SpriteRender spriteRender in SpriteRenders)
                {
                    spriteRender.Update(gameTime);
                }
                updateElapsedTime = 0;
            }
        }

        internal void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            ScreenResolution.BeginDraw();

            graphicsDevice.Clear(GameOptions.BACK_COLOR);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, ScreenResolution.getTransformationMatrix());
            foreach (SpriteRender spriteRender in SpriteRenders)
            {
                spriteRender.Draw(ref spriteBatch);
            }
            spriteBatch.End();
        }
    }
}
