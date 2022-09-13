using Leopotam.EcsLite;
using UnityEngine;

public class PongReflectionSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var inputFilter = world.Filter<Moveable>().Inc<Collidable>().End();

        foreach (int entity in inputFilter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);
            ref Collidable collidable = ref world.Get<Collidable>(entity);

            if (collidable.Detector.Detected)
            {
                // Play reflection sound

                var angle = Vector3.Angle(Vector3.one, moveable.Transform.position);

                angle += 90;

                moveable.Direction = Quaternion.Euler(0, angle, 0) * moveable.Direction;
            }
        }
    }
}