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

        /// <summary>
        /// The rate that the animations change to the next frame
        /// </summary>
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
        private float _fps;

        private double updateIntervalTime;
        private double updateElapsedTime;

        public AnimationController()
        {
            this.Animations = new List<Animation>();
            this.FPS = 60;
        }

        /// <summary>
        /// Adds an animation to a list of animations in this controller
        /// </summary>
        /// <param name="animation">The animation to be added</param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A rectangle surrounding the current sprite on the spritesheet</returns>
        public Rectangle GetCurrentFrame()
        {
            return this.Animations[this.CurrentAnimationIndex].GetCurrentFrame();
        }

        private void AdvanceToNextFrame()
        {
            this.Animations[this.CurrentAnimationIndex].AdvanceToNextFrame();
        }

        internal void Update(GameTime gameTime)
        {
            updateElapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (updateElapsedTime >= updateIntervalTime)
            {
                AdvanceToNextFrame();
                updateElapsedTime = 0;
            }
        }

        /// <summary>
        /// Changes the animation that is being used
        /// </summary>
        /// <param name="index">The index of the animation to be changed to</param>
        public void ChangeAnimation(int index)
        {
            this.CurrentAnimationIndex = index;
        }

        /// <summary>
        /// Changes the animation that is being used
        /// </summary>
        /// <param name="name">The name of the animation to be changed to</param>
        public void ChangeAnimation(string name)
        {
            int animationsCount = this.Animations.Count;
            for (int i = 0; i < animationsCount; i++)
            {
                if (this.Animations[i].Name == name)
                {
                    ChangeAnimation(i);
                    break;
                }
            }
        }
    }
}
