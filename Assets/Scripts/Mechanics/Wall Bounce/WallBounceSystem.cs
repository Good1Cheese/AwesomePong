using Leopotam.EcsLite;
using UnityEngine;

public class WallBounceSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<PongComponent>().Inc<Moveable>().Inc<CollidedMarker>().End();

        foreach (int entity in filter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);
            var angle = Vector3.Angle(Vector3.one, moveable.Transform.position);

            angle += 90;

            moveable.Direction = Quaternion.Euler(0, angle, 0) * moveable.Direction;
        }
    }
}