using UnityEngine;
using UnityEngine.SceneManagement;

namespace project
{
    public class MainMenu : MonoBehaviour
    {
        public GameSceneSO MainMenuScene;
        public LoadSceneEvent StartSceneEvent;

        public void OnStartSceneButtonClick()
        {
            StartSceneEvent.Raise();
            SceneManager.UnloadSceneAsync(MainMenuScene.Scene.editorAsset.name);
        }
    }
}