using Leopotam.EcsLite;

public class VelocityResetSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<Acceleratable>().Inc<Moveable>().Inc<ResetableMarker>().End();

        foreach (int entity in filter)
        {
            ref var moveable = ref world.Get<Moveable>(entity);

            moveable.CurrentVelocity = moveable.Velocity;
        }
    }
}