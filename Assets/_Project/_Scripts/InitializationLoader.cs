using EventSystem;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace project
{
    public class InitializationLoader : MonoBehaviour
    {
        public GameSceneSO ManagersScene;
        public LoadSceneEvent MainMenuSceneLoadEvent;

        private void Start()
        {
            ManagersScene.Scene.LoadSceneAsync(LoadSceneMode.Additive).Completed += OnManagerSceneLoadComplete;
        }

        private void OnManagerSceneLoadComplete(AsyncOperationHandle<SceneInstance> handle)
        {
            MainMenuSceneLoadEvent.Raise();
            SceneManager.UnloadSceneAsync(0);
        }
    }
}