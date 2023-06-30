using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        private readonly List<GameEventListener> eventListeners = new List<GameEventListener>();

        public void Raise()
        {
            Raise(null);
        }

        public void Raise(EventBody body)
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
            {
                eventListeners[i].OnEventRaised(body);
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!eventListeners.Contains(listener)) eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (eventListeners.Contains(listener)) eventListeners.Remove(listener);
        }
    }
}