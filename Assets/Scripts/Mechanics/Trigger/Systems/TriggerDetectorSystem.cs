using Leopotam.EcsLite;

public class TriggerDetectorSystem : IEcsInitSystem, IEcsDestroySystem
{
    private EcsWorld _world;

    public void Init(IEcsSystems systems)
    {
        _world = systems.GetWorld();

        var filter = _world.Filter<Moveable>().Inc<Triggerable>().End();

        foreach (int entity in filter)
        {
            ref Triggerable triggerable = ref _world.Get<Triggerable>(entity);

            triggerable.Detector.Triggered += Detect;
        }
    }

    private void Detect(ObstacleTrigger trigger)
    {
        var filter = _world.Filter<Moveable>().Inc<Triggerable>().End();

        foreach (int entity in filter)
        {
            ref Triggerable triggerable = ref _world.Get<Triggerable>(entity);

            if (!triggerable.Detector.Detected) { continue; }

            trigger.Trigger(_world, entity);

            _world.Add<TriggeredMarker>(entity);
        }
    }

    public void Destroy(IEcsSystems systems)
    {
        var filter = _world.Filter<Moveable>().Inc<Triggerable>().End();

        foreach (int entity in filter)
        {
            ref Triggerable triggerable = ref _world.Get<Triggerable>(entity);

            triggerable.Detector.Triggered -= Detect;
        }
    }
}