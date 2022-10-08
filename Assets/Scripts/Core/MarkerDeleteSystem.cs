using Leopotam.EcsLite;

public class MarkerDeleteSystem<T> : IEcsRunSystem where T : struct
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<T>().End();

        foreach (int entity in filter)
        {
            world.Del<T>(entity);
        }
    }
}