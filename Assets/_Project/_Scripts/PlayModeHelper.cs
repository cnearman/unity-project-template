using UnityEngine;
using UnityEngine.SceneManagement;

namespace project
{
    public class PlayModeHelper : MonoBehaviour
    {
#if UNITY_EDITOR
        [field: SerializeField]
        private GameSceneSO _managersScene { get; set; }

        private bool _shouldLoad = false;

        private void Awake()
        {
            if (!SceneManager.GetSceneByName(_managersScene.Scene.editorAsset.name).isLoaded)
            {
                _shouldLoad = true;
            }
        }

        private void Start()
        {
            if (_shouldLoad)
            {
                _managersScene.Scene.LoadSceneAsync(LoadSceneMode.Additive, true);
            }
        }
#endif
    }
}