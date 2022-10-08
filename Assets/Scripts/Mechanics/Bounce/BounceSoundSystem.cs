using Leopotam.EcsLite;

public class BounceSoundSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<TriggeredMarker>().Inc<PongSounds>().Exc<GateTriggeredMarker>().End();

        foreach (int entity in filter)
        {
            ref PongSounds sounds = ref world.Get<PongSounds>(entity);

            sounds.AudioSource.PlayOneShot(sounds.WallBounceClip);
        }
    }
}