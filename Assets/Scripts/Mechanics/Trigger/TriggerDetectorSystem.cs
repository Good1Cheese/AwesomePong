using Leopotam.EcsLite;

public class TriggerDetectorSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<Moveable>().Inc<Triggerable>().End();

        foreach (int entity in filter)
        {
            ref Triggerable detectable = ref world.Get<Triggerable>(entity);

            if (!detectable.Detector.Detected) { return; }

            if (detectable.Detector.Collider.CompareTag("Player"))
            {
                world.Add<PaddleTriggeredMarker>(entity);
            }
            else if (detectable.Detector.Collider.CompareTag("Wall"))
            {
                world.Add<WallTriggeredMarker>(entity);
            }
            else if (detectable.Detector.Collider.CompareTag("Gate"))
            {
                world.Add<GateTriggeredMarker>(entity);
            }

            world.Add<TriggeredMarker>(entity);
        }
    }
}