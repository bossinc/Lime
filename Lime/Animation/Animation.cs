using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime.Animation
{
    public class Animation
    {
        /// <summary>
        /// The name of the animation. Can be used to identify an animation
        /// </summary>
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        private string _name;

        private Rectangle BoundingFrameRect;

        private List<int> FrameOrder;

        private int CurrentFrame;

        private Point StartingPosition;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Name of the animation</param>
        /// <param name="startingPosition">The top right point of the first frame of the animation on the spritesheet</param>
        /// <param name="boundingFrameSize">The size of the sprite on the spritesheet</param>
        public Animation(string name, Point startingPosition, Point boundingFrameSize)
        {
            this.Name = name;
            this.BoundingFrameRect = new Rectangle(startingPosition, boundingFrameSize);
            this.StartingPosition = startingPosition;

            this.FrameOrder = new List<int>();
            this.CurrentFrame = 0;
        }

        
        internal Rectangle GetCurrentFrame()
        {
            return this.BoundingFrameRect;
        }

        /// <summary>
        /// Moves the rectangle surrounding the sprite on the spritesheet to the next position based on the fram order
        /// </summary>
        public void AdvanceToNextFrame()
        {
            this.CurrentFrame++;
            int frameIndex;
            if (this.FrameOrder.Count > 0)
            {
                if (this.CurrentFrame >= this.FrameOrder.Count)
                {
                    this.CurrentFrame = 0;
                }
                frameIndex = this.FrameOrder[this.CurrentFrame];
            }
            else
            {
                frameIndex = 0;
            }
            int frameWidth = this.BoundingFrameRect.Width;

            this.BoundingFrameRect.X = frameWidth * frameIndex;
        }

        /// <summary>
        /// Sets the frame order
        /// </summary>
        /// <param name="frameOrder">A list of valid frame numbers</param>
        public void SetFrameOrder(List<int> frameOrder)
        {
            this.FrameOrder = frameOrder;
        }
    }
}
