using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime
{
    public class Transform : Component
    {
        public const float MAX_DEGREES = 360;
        public const float MIN_DEGREES = 0;

        #region Properties
        /// <summary>
        /// The current position of the Transform
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return this._position;
            }
            set
            {
                this._position = value;
            }
        }
        private Vector2 _position;

        /// <summary>
        /// The current rotation of the Transform in degrees
        /// </summary>
        public float Rotation
        {
            get
            {
                return this._rotation;
            }
            private set
            {
                this._rotation = value;
            }
        }
        private float _rotation;

        /// <summary>
        /// The current scale of the Transform
        /// </summary>
        public Vector2 Scale
        {
            get
            {
                return this._scale;
            }
            set
            {
                this._scale = value;
            }
        }
        private Vector2 _scale;

        /// <summary>
        /// The parent of the Transform
        /// Set to null if does not have parent
        /// </summary>
        public Transform Parent
        {
            get
            {
                return this._parent;
            }
            private set
            {
                value.childern.Add(this);
                this._parent = value;
            }
        }
        private Transform _parent;

        private List<Transform> childern;

        /// <summary>
        /// The current local position of the transform based on its parent
        /// Set to null if does not have a parent
        /// </summary>
        public Vector2 LocalPosition
        {
            get
            {
                return this._localPosition;
            }
            set
            {
                this._localPosition = value;
            }
        }
        private Vector2 _localPosition;

        /// <summary>
        /// The current local rotation of the transform based on its parent
        /// Set to null if does not have a parent
        /// </summary>
        public Vector2 LocalRotation
        {
            get
            {
                return this._localRotation;
            }
            set
            {
                this._localRotation = value;
            }
        }
        private Vector2 _localRotation;

        #endregion Properties

        public Transform(Vector2 position)
        {
            this.Position = position;
            this.Rotation = 0;
            this.Scale = Vector2.One;

            this.childern = new List<Transform>();
        }

        public Transform(Vector2 position, float rotation)
        {
            this.Position = position;
            this.Rotation = rotation;
            this.Scale = Vector2.One;

            this.childern = new List<Transform>();
        }

        public Transform(Vector2 position, float rotation, Vector2 scale)
        {
            this.Position = position;
            this.Rotation = rotation;
            this.Scale = scale;


            this.childern = new List<Transform>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The Transforms that are childern to this Transform</returns>
        public List<Transform> GetChildren()
        {
            return this.childern;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">The index of the child</param>
        /// <returns>The child at this index</returns>
        public Transform GetChild(int index)
        {
            return this.childern[index];
        }

        /// <summary>
        /// Rotates the the Transform by degrees
        /// </summary>
        /// <param name="degrees">The amount of degrees to rotate the Transform</param>
        public void Rotate(float degrees)
        {
            this.Rotation += degrees;
            if (this.Rotation > MAX_DEGREES)
            {
                this.Rotation -= MAX_DEGREES + MIN_DEGREES;
            }
            else if (this.Rotation < MIN_DEGREES)
            {
                this.Rotation += MAX_DEGREES - MIN_DEGREES;
            }
        }

        /// <summary>
        /// Sets the Transform's parent
        /// </summary>
        /// <param name="parent">The parent's transform</param>
        public void SetParent(Transform parent)
        {
            this.Parent = parent;
        }

        private void TranslateChildern(Vector2 translation)
        {
            foreach (Transform child in GetChildren())
            {
                child.Translate(translation, Space.World);
            }
        }

        /// <summary>
        /// Moves the Transform
        /// </summary>
        /// <param name="translation">The amount to move this Transform</param>
        /// <param name="relativeTo">Only set to World, Self in not yet emplemeneted</param>
        public void Translate(Vector2 translation, Space relativeTo = Space.World)
        {
            Vector2 newTranslation;
            if (relativeTo == Space.World)
            {
                newTranslation = translation;
            }
            else if (relativeTo == Space.Self)
            {
                throw new NotImplementedException("Needs to calculate the direction the cube goes based on rotation");
            }
            else
                throw new KeyNotFoundException(relativeTo.ToString() + " has not been defined in Translate");

            this.Position += newTranslation;
            TranslateChildern(newTranslation);
        }

        /// <summary>
        /// Moves the Transform
        /// </summary>
        /// <param name="x">The amount to move this Transform on the x axis</param>
        /// <param name="y">The amount to move this Transform on the y axis</param>
        /// <param name="relativeTo">Only set to World, Self in not yet emplemeneted</param>
        public void Translate(float x, float y, Space relativeTo = Space.World)
        {
            this.Translate(new Vector2(x, y), relativeTo);
        }
    }
}
