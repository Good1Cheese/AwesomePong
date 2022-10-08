using Leopotam.EcsLite;

public class GateBounceSoundSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<PongMarker>().Inc<PongSounds>().Inc<GateTriggeredMarker>().End();

        foreach (int entity in filter)
        {
            ref PongSounds sounds = ref world.Get<PongSounds>(entity);

            sounds.AudioSource.PlayOneShot(sounds.ScoreClip);
        }
    }
}