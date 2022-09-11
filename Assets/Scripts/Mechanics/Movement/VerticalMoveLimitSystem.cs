using Leopotam.EcsLite;
using UnityEngine;

public class VerticalMoveLimitSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var inputFilter = world.Filter<Moveable>().End();

        foreach (int entity in inputFilter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);

            Vector3 position = moveable.Transform.position;

            position.z = Mathf.Clamp(position.z,
                                     moveable.VerticalMoveLimit.x,
                                     moveable.VerticalMoveLimit.y);

            moveable.Transform.position = position;
        }
    }
}