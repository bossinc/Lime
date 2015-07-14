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


        public virtual void OnMouseEnter(Collider collider, MouseState mouseState)
        {
        }
        public virtual void OnMouseOver(Collider collider, MouseState mouseState)
        {
        }
        public virtual void OnMouseUp(Collider collider, MouseState mouseState)
        {
        }
        public virtual void OnMouseDown(Collider collider, MouseState mouseState)
        {
        }
        public virtual void OnMouseExit(Collider collider, MouseState mouseState)
        {
        }
        public virtual void OnEnabled(BaseObject sender)
        {
        }
        public virtual void OnDisabled(BaseObject sender)
        {
        }
        public virtual void OnDestroyed(BaseObject sender)
        {

        }

    }
}
