using UnityEngine;

[CreateAssetMenu(fileName = "new Player_SO", menuName = "Entities/Player")]
public class Player_SO : Entity_SO
{
    public InputComponent inputComponent;
    public Moveable moveable;
    public VerticalPositionClamp moveLimit;

    public override void Init(GameObject gameObject)
    {
        PlayerControls controls = new();
        inputComponent.Controls = controls;
        controls.Enable();

        moveable.Transform = gameObject.transform;
        moveable.StartPosition = startPosition;
        moveable.CurrentVelocity = moveable.Velocity;
    }
}