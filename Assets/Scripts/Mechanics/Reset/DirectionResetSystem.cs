using Leopotam.EcsLite;
using UnityEngine;

public class DirectionResetSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<PongMarker>().Inc<Moveable>().Inc<ResetableMarker>().End();

        foreach (int entity in filter)
        {
            ref var moveable = ref world.Get<Moveable>(entity);

            moveable.Direction = Vector2.right;
        }
    }
}