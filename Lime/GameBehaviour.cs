using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Lime.PseudoPhysics;

namespace Lime
{
    public class GameBehaviour : Component
    {
        public GameBehaviour()
        {
        }
        /// <summary>
        /// Called when the GameBehavior is instatiated.
        /// base addes all of the events
        /// </summary>
        public override void Start()
        {
            Collider collider = GameObject.GetComponent<Collider>();
            collider.OnMouseEnter += OnMouseEnter;
            collider.OnMouseOver += OnMouseOver;
            collider.OnMouseUp += OnMouseUp;
            collider.OnMouseDown += OnMouseDown;
            collider.OnMouseExit += OnMouseExit;
            GameObject.EOnEnabled += OnEnabled;
            GameObject.EOnDisabled += OnDisabled;
            GameObject.OnDestroy += OnDestroyed;
            base.Start();
        }

        /// <summary>
        /// Called when the mouse enters the GameObject's Collider
        /// </summary>
        /// <param name="collider">The collider was acted on</param>
        /// <param name="mouseState">The current state of the mouse</param>
        public virtual void OnMouseEnter(Collider collider, MouseState mouseState)
        {
        }

        /// <summary>
        /// Called when the mouse is over the GameObject's Collider
        /// </summary>
        /// <param name="collider">The collider was acted on</param>
        /// <param name="mouseState">The current state of the mouse</param>
        public virtual void OnMouseOver(Collider collider, MouseState mouseState)
        {
        }

        /// <summary>
        /// Called when a mouse button is released while over the GameObject's Collider
        /// </summary>
        /// <param name="collider">The collider was acted on</param>
        /// <param name="mouseState">The current state of the mouse</param>
        public virtual void OnMouseUp(Collider collider, MouseState mouseState)
        {
        }

        /// <summary>
        /// Called when a mouse button is down while over the GameObject's Collider
        /// </summary>
        /// <param name="collider">The collider was acted on</param>
        /// <param name="mouseState">The current state of the mouse</param>
        public virtual void OnMouseDown(Collider collider, MouseState mouseState)
        {
        }

        /// <summary>
        /// Called when the mouse exits the GameObject's Collider
        /// </summary>
        /// <param name="collider">The collider was acted on</param>
        /// <param name="mouseState">The current state of the mouse</param>
        public virtual void OnMouseExit(Collider collider, MouseState mouseState)
        {
        }

        /// <summary>
        /// Called when the GameObject is enabled
        /// </summary>
        /// <param name="sender">The GameObject</param>
        public virtual void OnEnabled(BaseObject sender)
        {
        }

        /// <summary>
        /// Called when the GameObject is disabled
        /// </summary>
        /// <param name="sender">The GameObject</param>
        public virtual void OnDisabled(BaseObject sender)
        {
        }

        /// <summary>
        /// Called when the GameObject is destroyed
        /// </summary>
        /// <param name="sender">The GameObject</param>
        public virtual void OnDestroyed(BaseObject sender)
        {

        }

    }
}
