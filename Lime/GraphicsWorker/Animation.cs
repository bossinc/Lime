using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Lime
{
    class Animation
    {
        private string _name;
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

        private Rectangle BoundingFrameRect;

        private List<int> FrameOrder;

        private int CurrentFrame;

        private Point StartingPosition;

        public Animation(string name, Point boundingFrameSize, Point startingPosition)
        {
            this.Name = name;
            this.BoundingFrameRect = new Rectangle(startingPosition, boundingFrameSize);
            this.StartingPosition = startingPosition;

            this.FrameOrder = new List<int>();
            this.CurrentFrame = 0;
        }

        public Rectangle GetCurrentFrame()
        {
            return this.BoundingFrameRect;
        }

        public void AdvanceToNextFrame()
        {
            CurrentFrame++;
            int frameIndex = FrameOrder[CurrentFrame];
            int frameWidth = this.BoundingFrameRect.Width;

            this.BoundingFrameRect.X = frameWidth * frameIndex;
        }
    }
}
