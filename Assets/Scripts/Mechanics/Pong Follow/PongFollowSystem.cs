using Leopotam.EcsLite;
using UnityEngine;

public class PongFollowSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var pongFilter = world.Filter<Moveable>().Inc<PongMarker>().End();
        var followableFilter = world.Filter<PongFollowable>().End();

        foreach (int pongEntity in pongFilter)
        {
            ref Moveable pong = ref world.Get<Moveable>(pongEntity);

            foreach (int followableEntity in followableFilter)
            {
                ref PongFollowable followable = ref world.Get<PongFollowable>(followableEntity);

                Vector2 position = followable.Transform.position;

                position.y = Mathf.Lerp(position.y, pong.Transform.position.y, 5 * Time.deltaTime);

                followable.Transform.position = position;
            }
        }
    }
}