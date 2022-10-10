using Leopotam.EcsLite;
using UnityEngine;

public class ScoreSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<Scoreable>().Inc<ScoreMarker>().End();

        foreach (int entity in filter)
        {
            ref var scoreable = ref world.Get<Scoreable>(entity);

            scoreable.Score++;
        }
    }
}