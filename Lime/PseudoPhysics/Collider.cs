﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Lime.PseudoPhysics
{
    public abstract class Collider : Component
    {
        private Point _bounds;
        public Rectangle Bounds
        {
            get
            {
                Point topLeftCorner = this.Offset + this.GameObject.Transform.Position.ToPoint();
                topLeftCorner -= new Point(this._bounds.X / 2, this._bounds.Y / 2);
                return new Rectangle(topLeftCorner, this._bounds);
            }
            set
            {
                this._bounds = new Point(value.Width, value.Height);
            }
        }
        
        private Point _offset;
        /// <summary>
        /// Offsets the collider from the orgin of the collider
        /// </summary>
        public Point Offset
        {
            get
            {
                return this._offset;
            }
            set
            {
                this._offset = value;
            }
        }

        private Vector2 _lastPosition;
        protected Vector2 LastPosition
        {
            get
            {
                return this._lastPosition;
            }
            set
            {
                this._lastPosition = value;
            }
        }

        public bool Stale
        {
            get
            {
                return LastPosition == GameObject.Transform.Position;
            }
        }

        private List<Collider> _curColliders;
        public List<Collider> CurColliders
        {
            get
            {
                return this._curColliders;
            }
            protected set
            {
                this._curColliders = value;
            }
        }

        private List<Collider> LastColliders;

        private bool isLastMouseCollide;

        private bool _trigger;
        public bool Trigger
        {
            get
            {
                return this._trigger;
            }
            set
            {
                this._trigger = value;
            }
        }
        public Collider()
        {
            this.CurColliders = new List<Collider>();
            this.LastColliders = new List<Collider>();
            isLastMouseCollide = false;
        }

        public override void SetGameObject(GameObject gameObject)
        {
            base.SetGameObject(gameObject);
            this.LastPosition = this.GameObject.Transform.Position;
        }

        internal virtual bool Intersects(Collider collider)
        {
            if (Trigger)
                return false;
            if (this.Bounds.Intersects(collider.Bounds))
            {
                this.CurColliders.Add(collider);
                return true;
            }
            return false;
        }

        internal virtual bool TiggerIntersects(Collider collider)
        {
            if (Trigger)
            {
                if (this.Bounds.Intersects(collider.Bounds))
                {
                    return true;
                }
            }
            return false;
        }

        internal void AddCurCollider(Collider collider)
        {
            this.CurColliders.Add(collider);
        }

        internal void RemoveCurCollider(Collider collider)
        {
            this.CurColliders.Remove(collider);
        }

        internal void Update()
        {
            CollisionUpdate();
            TriggerUpdate();
            MouseUpdate();

            this.LastColliders = null;
            this.LastColliders = new List<Collider>();
            this.LastColliders.AddRange(CurColliders);

            this.LastPosition = this.GameObject.Transform.Position;
        }

        protected virtual void CollisionUpdate()
        {
            foreach (Collider collider in this.CurColliders)
            {
                //Enter collision
                if (!this.LastColliders.Contains(collider))
                {
                    OnCollisionEnter(collider);
                }
                //Stay collision
                if (this.LastColliders.Contains(collider))
                {
                    OnCollisionStay(collider);
                }
            }

            foreach (Collider collider in this.LastColliders)
            {
                //Exit collision
                if (!this.CurColliders.Contains(collider))
                {
                    OnCollisionExit(collider);
                }
            }
        }

        protected virtual void TriggerUpdate()
        {
        }

        protected virtual void MouseUpdate()
        {
            MouseState mouseState = Mouse.GetState();
            Point mousePosition = new Point((int)(mouseState.Position.X * GameOptions.V_SCREEN_FACTOR), (int)(mouseState.Y * GameOptions.V_SCREEN_FACTOR));
            if (this.Bounds.Contains(mousePosition))
            {
                if (isLastMouseCollide)
                {
                    OnMouseOver(this, mouseState);
                }
                else
                {
                    OnMouseEnter(this, mouseState);
                }

                if (mouseState.LeftButton == ButtonState.Pressed || mouseState.RightButton == ButtonState.Pressed || mouseState.MiddleButton == ButtonState.Pressed)
                {
                    OnMouseDown(this, mouseState);
                }
                if (mouseState.LeftButton == ButtonState.Released || mouseState.RightButton == ButtonState.Released || mouseState.MiddleButton == ButtonState.Released)
                {
                    OnMouseUp(this, mouseState);
                }

                isLastMouseCollide = true;
            }
            else
            {
                if (isLastMouseCollide)
                {
                    OnMouseExit(this, mouseState);
                }

                isLastMouseCollide = false;
            }
        }

        public delegate void OnCollide(Collider collider);
        public delegate void OnMouseCollide(Collider collider, MouseState mouseState);

        public event OnCollide OnCollisionEnter;
        public event OnCollide OnCollisionStay;
        public event OnCollide OnCollisionExit;

        public event OnMouseCollide OnMouseEnter;
        public event OnMouseCollide OnMouseOver;
        public event OnMouseCollide OnMouseUp;
        public event OnMouseCollide OnMouseDown;
        public event OnMouseCollide OnMouseExit;

        public event OnCollide OnTriggerEnter;
        public event OnCollide OnTriggerStay;
        public event OnCollide OnTriggerExit;
    }
}