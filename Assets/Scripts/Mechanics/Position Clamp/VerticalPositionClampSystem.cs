using Leopotam.EcsLite;
using UnityEngine;

public class VerticalPositionClampSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<Moveable>().Inc<VerticalPositionClamp>().End();

        foreach (int entity in filter)
        {
            ref var moveable = ref world.Get<Moveable>(entity);
            ref var clamp = ref world.Get<VerticalPositionClamp>(entity);

            Vector3 position = moveable.Transform.position;

            position.y = Mathf.Clamp(position.y, -clamp.Clamp, clamp.Clamp);

            moveable.Transform.position = position;
        }
    }
}