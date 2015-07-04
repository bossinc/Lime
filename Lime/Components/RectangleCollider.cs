using Microsoft.Xna.Framework;


namespace Lime
{
    class RectangleCollider : Collider
    {
        const int EXCLUSIVE_MINIMUM_SIZE = 0;

        /// <summary>
        /// Offset is used for moving the collision box away from the object
        /// </summary>
        private Vector2 _offset;
        public Vector2 Offset
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


        private Vector2 _size;
        public Vector2 Size
        {
            get
            {
                return this._size;
            }
            set
            {
                if (value.X > EXCLUSIVE_MINIMUM_SIZE && value.Y > EXCLUSIVE_MINIMUM_SIZE)
                {
                    this._size = value;
                }
                else
                {
                    throw new System.ArgumentException("The size of either the X or Y can not be 0.  If you don't want this to collide, then you should not be defining a collider.");
                }
            }
        }

        /// <summary>
        /// If this false, then collision will
        /// </summary>
        private bool _trigger;
        public bool Trigger
        {
            get
            {
                return _trigger;
            }
            set
            {
                this._trigger = value;
            }
        }

    }
}
