using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    private void Awake()
    {
        PlayerInputManager.ConnectController(this);
    }

    public abstract void Init(PlayerControls controls);
}

public enum PlayerInputActionType
{
    AttackAction,
    MoveAction,
    AbilityAction
}