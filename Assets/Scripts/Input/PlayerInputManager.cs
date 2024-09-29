public static class PlayerInputManager
{
    private static PlayerControls _controls;

    public static void ConnectController(InputController controller)
    {
        if (_controls == null) {
            _controls = new PlayerControls();
            _controls.Enable();
        }

        controller.Init(_controls);
    }
}
