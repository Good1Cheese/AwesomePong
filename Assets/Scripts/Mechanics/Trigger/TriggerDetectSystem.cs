using Leopotam.EcsLite;

public class TriggerDetectSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<Moveable>().Inc<Triggerable>().End();

        foreach (int entity in filter)
        {
            ref Triggerable triggerable = ref world.Get<Triggerable>(entity);

            if (!triggerable.TriggerDetector.Detected) { return; }

            world.Add<TriggeredMarker>(entity);
        }
    }
}