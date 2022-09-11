using UnityEngine.InputSystem;

public struct InputComponent
{
    public PlayerControls Controls { get; set; }

    public InputAction Main => Controls.Movement.Move;
}