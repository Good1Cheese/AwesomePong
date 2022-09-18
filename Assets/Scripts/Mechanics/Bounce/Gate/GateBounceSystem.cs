using Leopotam.EcsLite;
using UnityEngine;

public class GateBounceSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<PongMarker>().Inc<GateTriggeredMarker>().End();

        foreach (int entity in filter)
        {
            
        }
    }
}