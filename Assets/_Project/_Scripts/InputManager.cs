using project.Collections;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace project.Input
{
    public class InputManager : MonoBehaviour
    {
        private const int MAX_CACHED_INPUT_FRAMES = 10;

        private CircularBuffer<InputState> inputFrames;

        // Returns a copy of the current frame's inputs so that they can't be changed by other things
        public InputState GetCurrentFrameInputs()
        {
            return new InputState(inputFrames.Front());
        }

        private void Awake()
        {
            inputFrames = new CircularBuffer<InputState>(MAX_CACHED_INPUT_FRAMES, new InputState[1] { new InputState()});
        }

        private void Update()
        {
            var previousInput = inputFrames.Front();
            inputFrames.PushFront(
                new InputState(previousInput)
            );
            // This will force the input system to handle events after the state is populated. With this used we should set the Update Mode
            // of the input system to Process Events Manually.
            // https://docs.unity3d.com/Packages/com.unity.inputsystem@1.6/manual/Settings.html#update-mode
            // InputSystem.Update();
        }

        public void HandleMovementAxisInput(InputAction.CallbackContext context)
        {
            var currentInputFrame = inputFrames.Front();
            currentInputFrame.MovementAxisInput = context.ReadValue<Vector2>();
        }

        public void HandleDirectionAxisInput(InputAction.CallbackContext context)
        {
            var currentInputFrame = inputFrames.Front();
            currentInputFrame.DirectionAxisInput = context.ReadValue<Vector2>();
        }

        public void HandleParryButtonInput(InputAction.CallbackContext context)
        {
            var currentInputFrame = inputFrames.Front();
            currentInputFrame.ParryButton = ProcessButtonInputContext(currentInputFrame.ParryButton, context);
        }

        public void HandleAttackButtonInput(InputAction.CallbackContext context)
        {
            var currentInputFrame = inputFrames.Front();
            currentInputFrame.AttackButton = ProcessButtonInputContext(currentInputFrame.AttackButton, context);
        }

        private Button ProcessButtonInputContext(Button currentState, InputAction.CallbackContext context)
        {
            var buttonState = context.ReadValueAsButton() ? ButtonState.Pressed : ButtonState.None;
            if (context.started)
            {
                return new Button(currentState)
                {
                    State = buttonState,
                    WasPressed = context.started
                };
            }

            if (context.canceled)
            {
                return new Button(currentState)
                {
                    State = buttonState,
                    WasReleased = context.canceled
                };
            }

            return new Button(currentState)
            {
                State = buttonState
            };
        }
    }

    public class InputState
    {
        public InputState()
        {
            MovementAxisInput = Vector2.zero;
            DirectionAxisInput = Vector2.zero;
            ParryButton = new Button();
            AttackButton = new Button();
        }

        public InputState(InputState other)
        {
            MovementAxisInput = other.MovementAxisInput;
            DirectionAxisInput = other.DirectionAxisInput;
            ParryButton = other.ParryButton;
            AttackButton = other.AttackButton;
        }

        public Vector2 MovementAxisInput { get; set; } 
        public Vector2 DirectionAxisInput { get; set; }
        public Button ParryButton { get; set; }
        public Button AttackButton { get; set; } 
    }

    public struct Button
    {
        public Button(Button other)
        {
            State = other.State;
            WasReleased = false;
            WasPressed = false;
        }

        public ButtonState State;

        public bool WasPressed;

        public bool WasReleased;
    }

    public enum ButtonState
    {
        None = 0,
        Pressed = 1
    }
}
