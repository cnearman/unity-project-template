using UnityEngine;

namespace EventSystem
{
    public class EventBody
    {

    }

    public class IntEventBody : EventBody
    {
        public int Value;

        public IntEventBody(int value)
        {
            Value = value;
        }
    }

    public class Vector2EventBody : EventBody
    {
        public Vector2 Value { get; private set; }

        public Vector2EventBody(Vector2 value)
        {
            Value = value;
        }
    }
}