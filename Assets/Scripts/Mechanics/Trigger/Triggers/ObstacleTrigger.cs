using Leopotam.EcsLite;
using UnityEngine;

public abstract class ObstacleTrigger : MonoBehaviour
{
    public abstract void Trigger(EcsWorld world, in int entity);
}
