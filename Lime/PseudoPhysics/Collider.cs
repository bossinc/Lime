using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Lime.PseudoPhysics
{
    public abstract class Collider : Component
    {
        /// <summary>
        /// The rectangle that definds the bounds of the collider
        /// Setting: only sets the width and height
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                Point topLeftCorner = this.Offset + this.GameObject.Transform.Position.ToPoint();
                //topLeftCorner -= new Point(this._bounds.X / 2, this._bounds.Y / 2);
                return new Rectangle(topLeftCorner, this._bounds);
            }
            set
            {
                this._bounds = new Point(value.Width, value.Height);
            }
        }
        private Point _bounds;
        
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
        private Point _offset;

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
        private Vector2 _lastPosition;

        /// <summary>
        /// Returns whether or not if the GameObject has changed positions.
        /// </summary>
        public bool Stale
        {
            get
            {
                return LastPosition == GameObject.Transform.Position;
            }
        }

        /// <summary>
        /// The Colliders currently colliding with this Collider
        /// </summary>
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
        private List<Collider> _curColliders;

        private List<Collider> LastColliders;

        private bool isLastMouseCollide;
        private bool isLastMouseDown;

        /// <summary>
        /// If set to true other Colliders can pass through this Collider
        /// </summary>
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
        private bool _trigger;


        public Collider()
        {
            this.CurColliders = new List<Collider>();
            this.LastColliders = new List<Collider>();
            isLastMouseCollide = false;
            isLastMouseDown = false;
        }

        internal override void SetGameObject(GameObject gameObject)
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
            if (this.Enabled)
            {
                CollisionUpdate();
                TriggerUpdate();
                MouseUpdate();

                this.LastColliders = null;
                this.LastColliders = new List<Collider>();
                this.LastColliders.AddRange(CurColliders);

                this.LastPosition = this.GameObject.Transform.Position;
            }
        }

        protected virtual void CollisionUpdate()
        {
            foreach (Collider collider in this.CurColliders)
            {
                //Enter collision
                if (!this.LastColliders.Contains(collider))
                {
                    if(OnMouseEnter != null)
                        OnCollisionEnter(collider);
                }
                //Stay collision
                if (this.LastColliders.Contains(collider))
                {
                    if (OnCollisionStay != null)
                        OnCollisionStay(collider);
                }
            }

            foreach (Collider collider in this.LastColliders)
            {
                //Exit collision
                if (!this.CurColliders.Contains(collider))
                {
                    if (OnCollisionExit != null)
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
            Point mousePosition = new Point((int)(mouseState.Position.X * GameOptions.V_SCREEN_FACTOR), (int)(mouseState.Position.Y * GameOptions.V_SCREEN_FACTOR));
            if (this.Bounds.Contains(mousePosition))
            {
                if (isLastMouseCollide)
                {
                    if(OnMouseOver != null)
                        OnMouseOver(this, mouseState);
                }
                else
                {
                    if(OnMouseEnter != null)
                        OnMouseEnter(this, mouseState);
                }

                if (mouseState.LeftButton == ButtonState.Pressed || mouseState.RightButton == ButtonState.Pressed || mouseState.MiddleButton == ButtonState.Pressed)
                {
                    if(OnMouseDown != null)
                        OnMouseDown(this, mouseState);
                    isLastMouseDown = true;
                }
                else if (isLastMouseDown)
                {
                    if (OnMouseUp != null)
                        OnMouseUp(this, mouseState);
                    isLastMouseDown = false;
                }

                isLastMouseCollide = true;
            }
            else
            {
                if (isLastMouseCollide)
                {
                    if(OnMouseExit != null)
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
