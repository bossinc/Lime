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

        public static void LoadScene(int index)
        {
            CurrentSceneIndex = index;
        }

        public static void AddScene(string name)
        {
            Scenes.Add(new Scene(new GameManager(), name));
            LoadScene(Scenes.Count - 1);
        }

        public static void DestroyScene(int index)
        {
            Scenes.RemoveAt(index);
        }

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
