using Leopotam.EcsLite;

public class PositionResetSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<Moveable>().Inc<ResetableMarker>().End();

        foreach (int entity in filter)
        {
            ref var moveable = ref world.Get<Moveable>(entity);

            moveable.Transform.position = moveable.StartPosition;
        }
    }
}