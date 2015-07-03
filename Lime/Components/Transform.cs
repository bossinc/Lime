using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime
{
    class Transform : Component
    {
        public const float MAX_DEGREES = 360;
        public const float MIN_DEGREES = 0;
        #region Properties
        private Vector2 _position;
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

        private float _rotation;
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

        private Vector2 _scale;
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

        private Transform _parent;
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

        private List<Transform> childern;

        private Vector2 _localPosition;
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

        private Vector2 _localRotation;
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

        public List<Transform> GetChildern()
        {
            return this.childern;
        }

        public Transform GetChild(int index)
        {
            return this.childern[index];
        }

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

        public void SetParent(Transform parent)
        {
            this.Parent = parent;
        }

        private void TranslateChildern(Vector2 translation)
        {
            foreach (Transform child in GetChildern())
            {
                child.Translate(translation, Space.World);
            }
        }

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

        public void Translate(float x, float y, Space relativeTo = Space.World)
        {
            this.Translate(new Vector2(x, y), relativeTo);
        }
    }
}
