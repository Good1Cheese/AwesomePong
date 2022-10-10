using Leopotam.EcsLite;
using UnityEngine;

public class PaddleBounceSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<PaddleBounceable>().Inc<Moveable>().Inc<PaddleTriggeredMarker>().End();

        foreach (int entity in filter)
        {
            ref var moveable = ref world.Get<Moveable>(entity);
            ref var bounceable = ref world.Get<PaddleBounceable>(entity);
            ref var triggered = ref world.Get<PaddleTriggeredMarker>(entity);

            Vector3 paddle = triggered.Renderer.bounds.center;
            Vector3 pong = moveable.Transform.position;

            Vector3 direction = (pong - paddle).normalized;

            direction.x = Mathf.Clamp(direction.x, -bounceable.XDirectionValue, bounceable.XDirectionValue);
            direction.y = Mathf.Clamp(direction.y, -bounceable.YDirectionClamp, bounceable.YDirectionClamp);

            moveable.Direction = direction.normalized;
        }
    }
}