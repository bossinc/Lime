using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lime
{
    static class SceneManager
    {
        private static List<Scene> Scenes = new List<Scene>();
        private static int CurrentSceneIndex = 0;

        public static GameManager GetCurrentGameManager()
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
                    LoadScene(sceneCount);
                    break;
                }
            }
        }

        public static void AddScene(Scene scene)
        {
            Scenes.Add(scene);
        }

        public static void LoadScene(int index)
        {
            CurrentSceneIndex = index;
        }
    }
}
