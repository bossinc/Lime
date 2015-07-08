using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

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
        }
        public Collider(GameObject gameObject)
        {
            gameObject.AddComponent(this);
            this.LastPosition = this.GameObject.Transform.Position;
            this.CurColliders = new List<Collider>();
            this.LastColliders = new List<Collider>();
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

        internal virtual void Update()
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

            this.LastColliders = null;
            this.LastColliders = new List<Collider>();
            this.LastColliders.AddRange(CurColliders);

            this.LastPosition = this.GameObject.Transform.Position;
        }

        public delegate void OnCollide(Collider collider);

        public event OnCollide OnCollisionEnter;
        public event OnCollide OnCollisionStay;
        public event OnCollide OnCollisionExit;

        public event OnCollide OnTriggerEnter;
        public event OnCollide OnTriggerStay;
        public event OnCollide OnTriggerExit;
    }
}
