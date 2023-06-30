using EventSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace project
{
    public class SceneManagement : MonoBehaviour
    {
        public void LoadScene(GameEvent gEvent, EventBody eb)
        {
            if (!(gEvent is LoadSceneEvent))
            {
                return;
            }
            var sceneEvent = (LoadSceneEvent)gEvent;
            sceneEvent.Scene.Scene.LoadSceneAsync(LoadSceneMode.Additive);
        }
    }
}
