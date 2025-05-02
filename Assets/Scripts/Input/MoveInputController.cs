using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    [RequireComponent(typeof(CharacterMovement))]
    public class MoveInputController : InputController
    {
        private bool _isMoved;

        private CharacterMovement _movement;
        private InputAction _moveAction;

        private void FixedUpdate()
        {
            if (_isMoved)
                _movement.MoveToDirection(_moveAction.ReadValue<Vector2>(), Time.fixedDeltaTime);
        }

        public override void Init(PlayerControls controls)
        {
            _movement = GetComponent<CharacterMovement>();

            _moveAction = controls.ActionMap.MoveAction;

            _moveAction.started += OnActionStarted;
            _moveAction.canceled += OnActionCanceled;
        }

        private void OnActionCanceled(InputAction.CallbackContext obj)
        {
            _isMoved = false;
        }

        private void OnActionStarted(InputAction.CallbackContext obj)
        {
            _isMoved = true;
        }
    }
}