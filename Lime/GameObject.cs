using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime
{
    class GameObject : BaseObject
    {
        #region Properties

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
        private List<Component> components
        {
            get
            {
                return _components;
            }
            set
            {
                this._components = value;
            }
        }

        #endregion Properties

        #region Constructors

        public GameObject()
        {
            this.transform = new Transform(Vector2.Zero);
        }

        #endregion Constructors

        #region Methods

        public override void Update(GameTime gameTime)
        {
 	        throw new NotImplementedException();
        }

        private void Destroy()
        {
            GameManager.instance.RemoveGameObject(this);
        }

        /// <summary>
        /// Adds this GameObject to the singeton of GameManager
        /// </summary>
        public void Instantiate(GameObject gameObject, Vector2 postion)
        {
            SetId();
            this.transform.position = postion;
            GameManager.instance.AddGameObject(this);
        }

        /// <summary>
        /// Finds every GameObject with name.
        /// </summary>
        /// <param name="name">name of the GameObjects to be found</param>
        /// <returns>List of GameObjects found. If none returns a null</returns>
        public static List<GameObject> Find(string name)
        {
            return GameManager.instance.FindGameObjectsName(name);
        }

        /// <summary>
        /// Finds every GameObject with tag.
        /// </summary>
        /// <param name="tag">tag of the GameObjects to be found</param>
        /// <returns>List of GameObjects found. If not found returns null</returns>
        public static List<GameObject> FindWithTag(string tag)
        {
            return GameManager.instance.FindGameObjectsTag(tag);
        }

        /// <summary>
        /// Gets the component that is T class
        /// </summary>
        /// <typeparam name="T">The type of component</typeparam>
        /// <returns>Returns found componet. If not found returns null</returns>
        public Component GetComponent<T>()
        {
            foreach (Component component in this.components)
            {
                if (component is T)
                    return component;
            }
            return null;
        }

        public Component GetComponent(int id)
        {
            foreach (Component component in this.components)
            {
                if (component.instanceId == id)
                    return component;
            }
            return null;
        }

        /// <summary>
        /// Adds component to the list of components
        /// </summary>
        /// <param name="component">Component to be added</param>
        public void AddComponent(Component component)
        {
            this.components.Add(component);
        }

        public void DestroyComponent(Component component)
        {
            this.components.Remove(component);
        }

        #endregion Methods
    }
}
