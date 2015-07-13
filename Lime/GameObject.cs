using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime
{
    
    public class GameObject : BaseObject
    {
        #region Properties

        private string _tag;
        public string Tag
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
        public Transform Transform
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
        public string Name
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
        private List<Component> Components
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
            this.Components = new List<Component>();
            this.Transform = new Transform(Vector2.Zero);
        }

        #endregion Constructors

        #region Methods

        public override void Update(GameTime gameTime)
        {
        }

        private void Destroy()
        {
            GameManager.Instance.RemoveGameObject(this);
        }

        /// <summary>
        /// Adds this GameObject to the singeton of GameManager
        /// </summary>
        public void Instantiate(Vector2 postion)
        {
            SetId();
            this.Transform.Position = postion;
            GameManager.Instance.AddGameObject(this);
            foreach (Component component in this.Components)
            {
                if(component is Animation.SpriteRender)
                    GameManager.Instance.GraphicsManager.AddSpriteRender((Animation.SpriteRender)component);
                else if(component is PseudoPhysics.Collider)
                    GameManager.Instance.PseudoPhysicsManager.AddCollider((PseudoPhysics.Collider)component);
            }
            //this.OnCreated(this);
        }

        /// <summary>
        /// Finds every GameObject with name.
        /// </summary>
        /// <param name="name">name of the GameObjects to be found</param>
        /// <returns>List of GameObjects found. If none returns a null</returns>
        public static List<GameObject> Find(string name)
        {
            return GameManager.Instance.FindGameObjectsName(name);
        }

        /// <summary>
        /// Finds every GameObject with tag.
        /// </summary>
        /// <param name="tag">tag of the GameObjects to be found</param>
        /// <returns>List of GameObjects found. If not found returns null</returns>
        public static List<GameObject> FindWithTag(string tag)
        {
            return GameManager.Instance.FindGameObjectsTag(tag);
        }

        /// <summary>
        /// Gets the component that is T class
        /// </summary>
        /// <typeparam name="T">The type of component</typeparam>
        /// <returns>Returns found componet. If not found returns null</returns>
        public Component GetComponent<T>()
        {
            foreach (Component component in this.Components)
            {
                if (component is T)
                    return component;
            }
            return null;
        }

        public Component GetComponent(int id)
        {
            foreach (Component component in this.Components)
            {
                if (component.InstanceId == id)
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
            component.SetGameObject(this);
            this.Components.Add(component);
        }

        public void DestroyComponent(Component component)
        {
            this.Components.Remove(component);
        }

        private GameObject GetGameObject()
        {
            return this;
        }

        #endregion Methods


        public event ChangedEventHandler OnCreated;
    }
}
