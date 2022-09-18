using Leopotam.EcsLite;
using UnityEngine;

[CreateAssetMenu(fileName = "new Enemy_SO", menuName = "Entities/Enemy")]
public class Enemy_SO : Entity_SO
{
    public PongFollowable pongFollowable;
    public InputComponent inputComponent;
    public VerticalPositionLimitation moveLimit;

    public override void Init(GameObject gameObject)
    {
        PlayerControls controls = new();
        inputComponent.Controls = controls;
        controls.Enable();

        pongFollowable.Transform = gameObject.transform;
    }
}