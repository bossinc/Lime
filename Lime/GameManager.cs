using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime
{
    internal sealed class GameManager : Attribute
    {
        public static GameManager Instance
        {
            get
            {
                return SceneManager.GetCurrentGameManager();
            }
        }

        private PseudoPhysics.PseudoPhysicsManager _pseudoPhysicsManager;
        public PseudoPhysics.PseudoPhysicsManager PseudoPhysicsManager
        {
            get
            {
                return this._pseudoPhysicsManager;
            }
            private set
            {
                this._pseudoPhysicsManager = value;
            }
        }

        private Animation.GraphicsManager _graphicsManager;
        public Animation.GraphicsManager GraphicsManager
        {
            get
            {
                return this._graphicsManager;
            }
            private set
            {
                this._graphicsManager = value;
            }
        }

        private Input.InputManager _inputManager;
        public Input.InputManager InputManager
        {
            get
            {
                return this._inputManager;
            }
            private set
            {
                this._inputManager = value;
            }
        }

        private List<GameObject> GameObjects;


        private double updateIntervalTime;
        private double updateElapsedTime;

        public GameManager(PseudoPhysics.PseudoPhysicsManager pseudoPhysicsManager, Animation.GraphicsManager graphicsManager, Input.InputManager inputManager)
        {
            this.PseudoPhysicsManager = pseudoPhysicsManager;
            this.GraphicsManager = graphicsManager;
            this.InputManager = inputManager;
            GameObjects = new List<GameObject>();
            updateIntervalTime = 1 / GameOptions.MAX_UPDATE_FPS;
            updateElapsedTime = 0;
        }

        public void Update(GameTime gameTime)
        {
            updateElapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (updateElapsedTime >= updateIntervalTime)
            {
                this.PseudoPhysicsManager.Update();
                foreach (GameObject gameObject in this.GameObjects)
                {
                    gameObject.Update(gameTime);
                }
                updateElapsedTime = 0;
            }
        }

        public void AddGameObject(GameObject gameObject)
        {
            this.GameObjects.Add(gameObject);
        }

        public void RemoveGameObject(GameObject gameObject)
        {
            this.GameObjects.Remove(gameObject);
        }

        public List<GameObject> FindGameObjectsName(string name)
        {
            List<GameObject> foundGameObjects = new List<GameObject>();
            foreach (GameObject gameObject in this.GameObjects)
            {
                if(gameObject.Name == name)
                    foundGameObjects.Add(gameObject);
            }
            if (foundGameObjects == new List<GameObject>())
                return null;
            return foundGameObjects;
        }

        public List<GameObject> FindGameObjectsTag(string tag)
        {
            List<GameObject> foundGameObjects = new List<GameObject>();
            foreach (GameObject gameObject in this.GameObjects)
            {
                if (gameObject.Tag == tag)
                    foundGameObjects.Add(gameObject);
            }
            if (foundGameObjects == new List<GameObject>())
                return null;
            return foundGameObjects;
        }
    }
}
