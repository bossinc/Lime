using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lime
{
    public static class SceneManager
    {
        private static List<Scene> Scenes = new List<Scene>();
        private static int CurrentSceneIndex = 0;

        internal static GameManager GetCurrentGameManager()
        {
            if(Scenes.Count == 0)
                Scenes.Add(new Scene(
                    new GameManager(
                        new PseudoPhysics.PseudoPhysicsManager(), 
                        new Animation.GraphicsManager(), 
                        new Input.InputManager()), 
                    "Default"));
            return Scenes[CurrentSceneIndex].GameManager;
        }

        /// <summary>
        /// Load and show a different scene
        /// </summary>
        /// <param name="name">The new scene's name</param>
        public static void LoadScene(string name)
        {
            int sceneCount = Scenes.Count;
            for(int sceneIndex =  0; sceneIndex < sceneCount; sceneIndex++)
            {
                if(name == Scenes[sceneIndex].Name)
                {
                    LoadScene(sceneIndex);
                    break;
                }
            }
        }

        /// <summary>
        /// Load and show a different scene
        /// </summary>
        /// <param name="index">The new scene's index</param>
        public static void LoadScene(int index)
        {
            CurrentSceneIndex = index;
        }

        /// <summary>
        /// Add, load, and show a newly created scene
        /// </summary>
        /// <param name="name">The new scene's name</param>
        public static void AddScene(string name)
        {
            Scenes.Add(new Scene(new GameManager(), name));
            LoadScene(Scenes.Count - 1);
        }

        /// <summary>
        /// Remove a scene from the game
        /// </summary>
        /// <param name="index">The scene's index</param>
        public static void DestroyScene(int index)
        {
            Scenes.RemoveAt(index);
        }

        /// <summary>
        /// Remove a scene from the game
        /// </summary>
        /// <param name="index">The scene's name</param>
        public static void DestroyScene(string name)
        {
            int sceneCount = Scenes.Count;
            for (int sceneIndex = 0; sceneIndex < sceneCount; sceneIndex++)
            {
                if (name == Scenes[sceneIndex].Name)
                {
                    DestroyScene(sceneIndex);
                    break;
                }
            }
        }
    }
}
