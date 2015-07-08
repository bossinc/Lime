using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime.Animation
{
    public class AnimationController
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
                updateIntervalTime = 1 / this.FPS;
                updateElapsedTime = 0;
            }
        }

        private double updateIntervalTime;
        private double updateElapsedTime;

        public AnimationController()
        {
            this.Animations = new List<Animation>();
            this.FPS = 60;
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

        private void AdvanceToNextFrame()
        {
            this.Animations[this.CurrentAnimationIndex].AdvanceToNextFrame();
        }

        public void Update(GameTime gameTime)
        {
            updateElapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (updateElapsedTime >= updateIntervalTime)
            {
                AdvanceToNextFrame();
                updateElapsedTime = 0;
            }
        }

        public void ChangeAnimation(int index)
        {
            this.CurrentAnimationIndex = index;
        }
    }
}
