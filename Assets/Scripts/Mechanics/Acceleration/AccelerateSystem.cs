using Leopotam.EcsLite;
using UnityEngine;

public class AccelerateSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<Acceleratable>().Inc<Moveable>().Inc<TriggeredMarker>().Exc<GateTriggeredMarker>().End();

        foreach (int entity in filter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);
            ref Acceleratable acceleratable = ref world.Get<Acceleratable>(entity);

            moveable.CurrentVelocity *= acceleratable.Progress;

            moveable.CurrentVelocity = Mathf.Clamp(moveable.CurrentVelocity,
                                                   acceleratable.Min,
                                                   acceleratable.Max);
        }
    }
}