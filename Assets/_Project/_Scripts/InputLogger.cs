using System;
using TMPro;
using UnityEngine;

namespace project.Input.Test 
{ 
    public class InputLogger : MonoBehaviour
    {
        public TextMeshProUGUI MovementVectorValue;
        public TextMeshProUGUI DirectionVectorValue;
        public TextMeshProUGUI AttackButtonValue;

        private InputManager _manager;

        public void Start()
        {
            _manager = FindObjectOfType<InputManager>();
        }

        // Update is called once per frame
        private void Update()
        {
            var input = _manager.GetCurrentFrameInputs();
            MovementVectorValue.text = input.MovementAxisInput.ToString();
            DirectionVectorValue.text = input.DirectionAxisInput.ToString();
            AttackButtonValue.text = Enum.GetName(typeof(ButtonState), input.AttackButton.State);
            if (input.AttackButton.WasPressed)
            {
                Debug.Log("Attack Button Pressed");
            }
            if (input.AttackButton.WasReleased)
            {
                Debug.Log("Attack Button Released");
            }
        }
    }
}