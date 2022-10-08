using Leopotam.EcsLite;
using UnityEngine;

public class BorderBounceSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<PongMarker>().Inc<Moveable>().Inc<BorderTriggeredMarker>().End();

        foreach (int entity in filter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);

            Vector2 direction = moveable.Direction;
            direction.y = -direction.y;

            moveable.Direction = direction;
        }
    }
}