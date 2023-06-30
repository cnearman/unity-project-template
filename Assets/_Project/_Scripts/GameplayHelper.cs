using UnityEngine;
using UnityEngine.SceneManagement;

namespace project
{
    public class GameplayHelper : MonoBehaviour
    {
#if UNITY_EDITOR
        [field: SerializeField]
        private GameSceneSO _gameplayManagersScene { get; set; }

        private bool _shouldLoad = false;

        private void Awake()
        {
            if (!SceneManager.GetSceneByName(_gameplayManagersScene.Scene.editorAsset.name).isLoaded)
            {
                //_shouldLoad = true;
                _gameplayManagersScene.Scene.LoadSceneAsync(LoadSceneMode.Additive, true);
            }
        }

        private void Start()
        {
            if (_shouldLoad)
            {
            }
        }
#endif
    }
}