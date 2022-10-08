using Leopotam.EcsLite;
using System.Linq;

public static class EcsExtensions
{
    public static ref T Add<T>(this EcsWorld ecsWorld, in int entity, in T existing) where T : struct
    {
        ref T component = ref Add<T>(ecsWorld, entity);

        component = existing;

        return ref component;
    }

    public static ref T Add<T>(this EcsWorld ecsWorld, in int entity) where T : struct
    {
        EcsPool<T> ecsPool = ecsWorld.GetPool<T>();

        return ref ecsPool.Add(entity);
    }

    public static ref T Get<T>(this EcsWorld ecsWorld, in int entity) where T : struct
    {
        EcsPool<T> ecsPool = ecsWorld.GetPool<T>();

        return ref ecsPool.Get(entity);
    }

    public static void Del<T>(this EcsWorld ecsWorld, in int entity) where T : struct
    {
        EcsPool<T> ecsPool = ecsWorld.GetPool<T>();

        ecsPool.Del(entity);
    }

    public static void AddNewIfThereIsNot<T>(this EcsSystems ecsSystems) where T : class, IEcsSystem, new()
    {
        if (ecsSystems.Has<T>()) { return; }

        ecsSystems.Add(new T());
    }

    private static bool Has<T>(this EcsSystems ecsSystems) where T : class, IEcsSystem, new()
    {
        var systems = ecsSystems.GetAllSystems();

        return systems.Any(s => (s as T) != null);
    }
}