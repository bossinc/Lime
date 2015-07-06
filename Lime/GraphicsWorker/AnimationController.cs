using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime
{
    class AnimationController
    {
        private List<Animation> Animations;

        private int CurrentAnimationIndex;

        private float _fps;
        public float FPS
        {
            get
            {
                return this._fps;
            }
            set
            {
                this._fps = value;
            }
        }

        public AnimationController()
        {
            this.Animations = new List<Animation>();
        }

        public void AddAnimation(Animation animation)
        {
            this.Animations.Add(animation);
        }

        private Animation GetAnimation(string name)
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

        public Rectangle GetCurrentFrame()
        {
            return this.Animations[this.CurrentAnimationIndex].GetCurrentFrame();
        }

        public void AdvanceToNextFrame()
        {
            this.Animations[this.CurrentAnimationIndex].AdvanceToNextFrame();
        }

        public void ChangeAnimation(int index)
        {
            this.CurrentAnimationIndex = index;
        }
    }
}
