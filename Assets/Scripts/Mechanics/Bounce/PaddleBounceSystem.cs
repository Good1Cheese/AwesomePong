using Leopotam.EcsLite;
using UnityEngine;

public class PaddleBounceSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<PongPaddleBounceable>().Inc<Moveable>().Inc<PaddleTriggeredMarker>().End();

        foreach (int entity in filter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);
            ref PongPaddleBounceable bounceable = ref world.Get<PongPaddleBounceable>(entity);
            ref PaddleTriggeredMarker triggered = ref world.Get<PaddleTriggeredMarker>(entity);

            Vector3 paddle = triggered.Renderer.bounds.center;
            Vector3 pong = moveable.Transform.position;

            Vector3 direction = (pong - paddle).normalized;

            direction.x = Mathf.Clamp(direction.x, -bounceable.HorizontalClamp, bounceable.HorizontalClamp);
            direction.y = Mathf.Clamp(direction.y, -bounceable.VerticalClamp, bounceable.VerticalClamp);

            moveable.Direction = direction;
        }
    }
}