using Leopotam.EcsLite;
using UnityEngine;

public class ScoreSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<Scoreable>().Inc<ScoreMarker>().End();

        foreach (int entity in filter)
        {
            ref Scoreable scoreable = ref world.Get<Scoreable>(entity);

            scoreable.Score++;
        }
    }
}