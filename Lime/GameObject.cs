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

        /// <summary>
        /// Can be used to identify a GameObject
        /// </summary>
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
        private string _tag;

        /// <summary>
        /// Used to determine drawing and collision locations
        /// </summary>
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
        private Transform _transform;

        /// <summary>
        /// Can be used to identify a GameObject
        /// </summary>
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
        private string _name;

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
        private List<Component> _components;

        #endregion Properties

        #region Constructors

        public GameObject()
        {
            Console.WriteLine(this.GetType());
            this.Components = new List<Component>();
            this.Transform = new Transform(Vector2.Zero);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// DO NOT USE
        /// </summary>
        /// <param name="gameTime"></param>
        public sealed override void Update(GameTime gameTime)
        {
            foreach (Component component in Components)
            {
                if (!(component is Animation.SpriteRender) && !(component is PseudoPhysics.Collider))
                    component.Update(gameTime);
            }
        }

        /// <summary>
        /// Adds this GameObject to the current scene
        /// </summary>
        public static GameObject Instantiate(GameObject gameObject, Vector2 postion)
        {
            gameObject.SetId();
            gameObject.Transform.Position = postion;
            gameObject.AddComponent(gameObject.Transform);
            GameManager.Instance.AddGameObject(gameObject);
            foreach (Component component in gameObject.Components)
            {
                if(component is Animation.SpriteRender)
                    GameManager.Instance.GraphicsManager.AddSpriteRender((Animation.SpriteRender)component);
                else if(component is PseudoPhysics.Collider)
                    GameManager.Instance.PseudoPhysicsManager.AddCollider((PseudoPhysics.Collider)component);
                component.StartInternal();
            }
            if(gameObject.OnCreated != null)
                gameObject.OnCreated(gameObject);

            return gameObject;
        }

        /// <summary>
        /// Adds this GameObject to the current scene
        /// </summary>
        public static GameObject Instantiate(GameObject gameObject)
        {
            return Instantiate(gameObject, gameObject.Transform.LocalPosition);
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
        public T GetComponent<T>() where T : class
        {
            for (int i = 0; i < this.Components.Count; i++)
            {
                if (this.Components[i] is T)
                    return this.Components[i] as T;
            }
            return null;
        }

        /// <summary>
        /// Adds component to the list of components
        /// </summary>
        /// <param name="component">Component to be added</param>
        public void AddComponent(Component component)
        {
            component.SetGameObject((GameObject)this);
            this.Components.Add(component);
        }

        /// <summary>
        /// Removes the component from the game
        /// </summary>
        /// <param name="component">The component to be destroyed</param>
        public void DestroyComponent(Component component)
        {
            this.Components.Remove(component);
        }

        /// <summary>
        /// Removes all components from the game associated with the object
        /// </summary>
        public void DestroyComponents()
        {
            GameManager.Instance.GraphicsManager.DeleteSpriteRender(GetComponent<Animation.SpriteRender>());
            GameManager.Instance.PseudoPhysicsManager.DeleteCollider(GetComponent<PseudoPhysics.Collider>());
            this.Components.Clear();
            this.Components = new List<Component>();
        }

        public void Enable()
        {
            GameManager.Instance.GraphicsManager.AddSpriteRender(GetComponent<Animation.SpriteRender>());
            GameManager.Instance.PseudoPhysicsManager.AddCollider(GetComponent<PseudoPhysics.Collider>());

        }

        public void Disable()
        {
            GameManager.Instance.GraphicsManager.DeleteSpriteRender(GetComponent<Animation.SpriteRender>());
            GameManager.Instance.PseudoPhysicsManager.DeleteCollider(GetComponent<PseudoPhysics.Collider>());
        }


        private GameObject GetGameObject()
        {
            return this;
        }

        public int GetComponentCount()
        {
            return this.Components.Count;
        }

        #endregion Methods


        public event ChangedEventHandler OnCreated;
    }
}
