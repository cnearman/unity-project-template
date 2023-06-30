using UnityEngine;
using UnityEngine.AddressableAssets;

namespace project
{
    [CreateAssetMenu(menuName = "Game Scene")]
    public class GameSceneSO : ScriptableObject
    {
        public AssetReference Scene;
    }
}