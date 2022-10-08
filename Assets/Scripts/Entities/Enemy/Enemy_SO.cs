using UnityEngine;

[CreateAssetMenu(fileName = "new Enemy_SO", menuName = "Entities/Enemy")]
public class Enemy_SO : Entity_SO
{
    public PongFollowable pongFollowable;

    public override void Init(GameObject gameObject)
    {
        pongFollowable.Transform = gameObject.transform;
    }
}