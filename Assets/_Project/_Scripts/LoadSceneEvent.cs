using EventSystem;
using UnityEngine;

namespace project
{
    [CreateAssetMenu(menuName = "Events/Load Scene")]
    public class LoadSceneEvent : GameEvent
    {
        [field: SerializeField]
        public GameSceneSO Scene { get; set; }
    }
}