using Leopotam.EcsLite;
using UnityEngine;

public class VerticalPositionLimitationSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<Moveable>().Inc<VerticalPositionLimitation>().End();

        foreach (int entity in filter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);
            ref VerticalPositionLimitation limit = ref world.Get<VerticalPositionLimitation>(entity);

            Vector3 position = moveable.Transform.position;

            position.y = Mathf.Clamp(position.y, limit.Min, limit.Max);

            moveable.Transform.position = position;
        }
    }
}