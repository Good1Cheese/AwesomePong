using Leopotam.EcsLite;

public class VelocityResetSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<Acceleratable>().Inc<Moveable>().Inc<Resetable>().End();

        foreach (int entity in filter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);

            moveable.CurrentVelocity = moveable.Velocity;
        }
    }
}