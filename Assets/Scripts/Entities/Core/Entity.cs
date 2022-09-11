using Leopotam.EcsLite;

public abstract class Entity
{
    protected EcsWorld _world;
    protected EcsSystems _systems;

    protected Entity(EcsWorld ecsWorld, EcsSystems ecsSystems)
    {
        _world = ecsWorld;
        _systems = ecsSystems;
    }

    public abstract void Init();
}