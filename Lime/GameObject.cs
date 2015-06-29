using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime
{
    class GameObject
    {
        #region Properties

        private int _id;
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        private bool _active;
        public bool active
        {
            get
            {
                return this._active;
            }
            set
            {
                this._active = value;
            }
        }

        private string _tag;
        public string tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                this._tag = value;
            }
        }

        private Transform _transform;
        public Transform transform
        {
            get
            {
                return _transform;
            }
            set
            {
                this._transform = value;
            }
        }

        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                this._name = value;
            }
        }

        private List<Component> _components;
        public List<Component> Components
        {
            get
            {
                return _components;
            }
        }

        #endregion Properties

        #region Constructors

        public GameObject()
        {
        }

        #endregion Constructors

        #region Methods

        public void Update(GameTime gameTime)
        {

        }

        public void Destroy()
        {
        }

        public void Instantiate()
        {
        }

        public GameObject Find(string name)
        {
            return null;
        }

        public GameObject FindWithTag(string tag)
        {
            return null;
        }

        public Component GetComponet<T>()
        {
            return null;
        }


        #endregion Methods

        #region Events


        #endregion Events
    }
}
