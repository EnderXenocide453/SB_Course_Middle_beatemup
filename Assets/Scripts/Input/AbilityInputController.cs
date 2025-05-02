using Abilities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class AbilityInputController : InputController
    {
        [SerializeField] PlayerInputActionType actionType;
        [SerializeField] BaseAbility ability;
        private IAbilityEnder _abilityEnder;

        public override void Init(PlayerControls controls)
        {
            if (ability == null) {
                Debug.LogError("Не назначено действие");
                return;
            }

            var action = GetAction(actionType, controls);
            action.started += OnStarted;

            if (ability is IAbilityEnder ender) {
                _abilityEnder = ender;
                action.canceled += OnEnded;
            }

        }

        private void OnEnded(InputAction.CallbackContext obj)
        {
            _abilityEnder.EndExecution();
        }

        private void OnStarted(InputAction.CallbackContext obj)
        {
            ability.Execute();
        }

        protected InputAction GetAction(PlayerInputActionType type, PlayerControls controls) => controls.FindAction(type.ToString());
    }
}