using Leopotam.EcsLite;
using System.Linq;

public static class EcsExtensions
{
    public static void Add<T>(this EcsWorld ecsWorld, int entity, T existing) where T : struct
    {
        EcsPool<T> ecsPool = ecsWorld.GetPool<T>();

        ref T component = ref ecsPool.Add(entity);

        component = existing;
    }

    public static ref T Get<T>(this EcsWorld ecsWorld, int entity) where T : struct
    {
        EcsPool<T> ecsPool = ecsWorld.GetPool<T>();

        return ref ecsPool.Get(entity);
    }

    public static void AddIfDoesnNotHas<T>(this EcsSystems ecsSystems) where T : class, IEcsSystem, new()
    {
        if (ecsSystems.Has<T>()) { return; }

        ecsSystems.Add(new T());
    }

    public static bool Has<T>(this EcsSystems ecsSystems) where T : class, IEcsSystem, new()
    {
        var systems = ecsSystems.GetAllSystems();

        return systems.Any(s => s as T != null);
    }
}