using Leopotam.EcsLite;
using UnityEngine;

public class ZCoordinateLimitationSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var inputFilter = world.Filter<Moveable>().Inc<PositionLimitation>().End();

        foreach (int entity in inputFilter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);
            ref PositionLimitation limit = ref world.Get<PositionLimitation>(entity);

            Vector3 position = moveable.Transform.position;

            position.z = Mathf.Clamp(position.z,
                                     limit.Min,
                                     limit.Max);

            moveable.Transform.position = position;
        }
    }
}