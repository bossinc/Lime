using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lime
{
    internal sealed class GameManager : Attribute
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();
                return _instance;
            }
        }

        private List<GameObject> GameObjects;


        private double updateIntervalTime;
        private double updateElapsedTime;

        public GameManager()
        {
            GameObjects = new List<GameObject>();
            updateIntervalTime = 1 / GameOptions.MAX_UPDATE_FPS;
            updateElapsedTime = 0;
        }

        public void Update(GameTime gameTime)
        {
            updateElapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (updateElapsedTime >= updateIntervalTime)
            {
                Lime.PseudoPhysics.PseudoPhysicsManager.Instance.Update();
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
