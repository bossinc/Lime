using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Lime
{
    class GraphicsManager
    {
        private static GraphicsManager _instance;
        public static GraphicsManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GraphicsManager();
                return _instance;
            }
        }

        private List<SpriteRender> SpriteRenders;

        private ContentManager _content;
        public ContentManager Content
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

        public GraphicsManager()
        {
            this.SpriteRenders = new List<SpriteRender>();
        }

        public void AddSpriteRender(SpriteRender spriteRender)
        {
            this.SpriteRenders.Add(spriteRender);
        }

        public void Update(GameTime gameTime)
        {
            foreach (SpriteRender spriteRender in SpriteRenders)
            {
                spriteRender.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ScreenResolution.BeginDraw();
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, ScreenResolution.getTransformationMatrix());
            foreach (SpriteRender spriteRender in SpriteRenders)
            {
                spriteRender.Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}
