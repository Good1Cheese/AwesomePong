using Leopotam.EcsLite;

public class WallBounceSoundSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<PongComponent>().Inc<CollidedMarker>().End();

        foreach (int entity in filter)
        {
            ref PongComponent pong = ref world.Get<PongComponent>(entity);

            pong.AudioSource.PlayOneShot(pong.WallBounceClip);
        }
    }
}
