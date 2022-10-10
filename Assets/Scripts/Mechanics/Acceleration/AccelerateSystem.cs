using Leopotam.EcsLite;
using UnityEngine;

public class AccelerateSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<Acceleratable>().Inc<Moveable>().Inc<TriggeredMarker>().Exc<GateTriggeredMarker>().End();

        foreach (int entity in filter)
        {
            ref var moveable = ref world.Get<Moveable>(entity);
            ref var acceleratable = ref world.Get<Acceleratable>(entity);

            moveable.CurrentVelocity *= acceleratable.Progress;

            moveable.CurrentVelocity = Mathf.Clamp(moveable.CurrentVelocity,
                                                   acceleratable.Min,
                                                   acceleratable.Max);
        }
    }
}