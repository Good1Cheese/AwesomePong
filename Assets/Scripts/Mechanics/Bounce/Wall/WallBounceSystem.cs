using Leopotam.EcsLite;
using UnityEngine;

public class WallBounceSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<Moveable>().Inc<PaddleTriggeredMarker>().End();

        foreach (int entity in filter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);

            Vector2 direction = moveable.Direction;
            direction.x = -direction.x;

            moveable.Direction = direction;
        }
    }
}