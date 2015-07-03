﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime
{
    class Transform : Component
    {
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
            set
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
            set
            {
                this._parent = value;
            }
        }

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
        }

        public Transform(Vector2 position, float rotation, Vector2 scale)
        {
        }


    }
}
