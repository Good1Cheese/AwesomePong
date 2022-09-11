using Leopotam.EcsLite;

public static class EcsExtensions
{
    public static void Add<T>(this EcsWorld world, int entity, T existing) where T : struct
    {
        EcsPool<T> ecsPool = world.GetPool<T>();

        ref T component = ref ecsPool.Add(entity);

        component = existing;
    } 
}