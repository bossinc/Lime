using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lime
{
    class GameManager
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

        private List<GameObject> gameObjects;

        public GameManager()
        {
            gameObjects = new List<GameObject>();
        }

        public void Update()
        {
            
        }

        public void AddGameObject(GameObject gameObject)
        {
            this.gameObjects.Add(gameObject);
        }

        public void RemoveGameObject(GameObject gameObject)
        {
            this.gameObjects.Remove(gameObject);
        }

        public List<GameObject> FindGameObjectsName(string name)
        {
            List<GameObject> foundGameObjects = new List<GameObject>();
            foreach (GameObject gameObject in this.gameObjects)
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
            foreach (GameObject gameObject in this.gameObjects)
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
