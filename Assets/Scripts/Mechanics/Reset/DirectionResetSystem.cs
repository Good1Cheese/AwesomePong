using Leopotam.EcsLite;
using UnityEngine;

public class DirectionResetSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<PongMarker>().Inc<Moveable>().Inc<GameStartedMarker>().End();

        foreach (int entity in filter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);

            moveable.Direction = Vector2.right;
        }
    }
}