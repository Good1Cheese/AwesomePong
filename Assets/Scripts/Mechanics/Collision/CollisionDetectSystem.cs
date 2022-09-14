using Leopotam.EcsLite;

public class CollisionDetectSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<Moveable>().Inc<Collidable>().End();

        foreach (int entity in filter)
        {
            ref Collidable collidable = ref world.Get<Collidable>(entity);

            if (!collidable.CollisionDetector.Detected) { return; }

            world.Add<CollidedMarker>(entity);
        }
    }
}