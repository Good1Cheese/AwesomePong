using UnityEngine;

[CreateAssetMenu(fileName = "new Pong_SO", menuName = "Entities/Pong")]
public class Pong_SO : Entity_SO
{
    public Moveable moveable;
    public PongSounds pongSounds;
    public Triggerable triggerable;
    public Acceleratable acceleratable;

    public override void Init(GameObject gameObject)
    {
        moveable.Transform = gameObject.transform;
        moveable.StartPosition = startPosition;
        moveable.Direction = Vector2.left;
        moveable.CurrentVelocity = moveable.Velocity;

        pongSounds.AudioSource = gameObject.GetComponent<AudioSource>();

        triggerable.Detector = gameObject.GetComponent<TriggerDetection>();
    }
}