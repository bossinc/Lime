using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime
{
    class Collider : Component
    {
        private List<Point> _collisionPoints;
        public List<Point> CollisionPoints
        {
            get
            {
                return this._collisionPoints;
            }
            set
            {
                this._collisionPoints = value;
            }
        }

        private Collider _lastCollider;
        public Collider LastCollider
        {
            get
            {
                return this._lastCollider;
            }
            set
            {
                _lastCollider = value;
            }
        }

        private bool _isTrigger;
        public bool IsTrigger
        {
            get
            {
                return this._isTrigger;
            }
            set
            {
                this._isTrigger = value;
            }
        }

        public Collider()
        {
        }

        /// <summary>
        /// Compares another collider and activates the appropriate events
        /// </summary>
        /// <param name="collider">The other object we are colliding with</param>
        public void compare(Collider collider)
        {
            bool colliding = false;
            foreach(Point point in collider.CollisionPoints)
            {
                if(this.isInside(point))
                {
                    colliding = true;
                }
            }

            if(colliding)
            {

            }
        }

        // TODO: use absolute positioning, since the CollisionPoints are relative to the center of the Collider.
        /// <summary>
        /// Takes a point and calculates if it is inside a shape.
        /// Uses the AbsoluteCollisionPoints property to define the shape
        /// </summary>
        /// <param name="point">The point that is being checked</param>
        /// <returns>True if the point is inside the shape, false if it is not.</returns>
        public bool isInside(Point point)
        {
            int counter = 0;
            int counter2 = this.CollisionPoints.Count - 1;
            bool isInside = false;
            while (counter < this.CollisionPoints.Count)
            {
                if((this.CollisionPoints[counter].Y > point.Y) != (this.CollisionPoints[counter2].Y > point.Y))
                {
                    if(point.X < (this.CollisionPoints[counter2].X - this.CollisionPoints[counter].X) 
                        * (point.Y - this.CollisionPoints[counter].Y) 
                        / (this.CollisionPoints[counter2].Y - this.CollisionPoints[counter].Y) 
                        + this.CollisionPoints[counter].X)
                    {
                        isInside = !isInside;
                    }
                }
                counter++;
                counter2 = counter + 1;
            }
            return isInside;
        }

        public delegate void OnCollide(BaseObject collider);

        public event OnCollide OnCollisionEnter;
        public event OnCollide OnCollisionStay;
        public event OnCollide OnCollisionExit;
    }
}
