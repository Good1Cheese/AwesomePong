using Leopotam.EcsLite;
using UnityEngine;

public class ScoreSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<PongComponent>().Inc<TriggeredMarker>().End();

        foreach (int entity in filter)
        {
            Time.timeScale = 0;
        }
    }
}