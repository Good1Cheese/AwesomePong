using Leopotam.EcsLite;
using UnityEngine;

public class VerticalPositionClampSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<Moveable>().Inc<VerticalPositionClamp>().End();

        foreach (int entity in filter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);
            ref VerticalPositionClamp clamp = ref world.Get<VerticalPositionClamp>(entity);

            Vector3 position = moveable.Transform.position;

            position.y = Mathf.Clamp(position.y, clamp.Min, clamp.Max);

            moveable.Transform.position = position;
        }
    }
}