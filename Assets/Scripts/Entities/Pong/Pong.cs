using Leopotam.EcsLite;
using Zenject;

public class Pong : SpawnableEntity
{
    public Pong(Pong_SO entity_SO, EcsWorld ecsWorld, EcsSystems ecsSystems)
        : base(entity_SO, ecsWorld, ecsSystems)
    {
    }

    protected override void AddComponents()
    {
        int entity = _world.NewEntity();
        var pong_SO = (Pong_SO)_entity_SO;

        pong_SO.moveable.Transform = _gameObject.transform;

        _world.Add(entity, pong_SO.moveable);
    }

    protected override void AddSystems()
    {
        _systems.AddIfDoesnNotHas<PongSystem>();
        _systems.AddIfDoesnNotHas<MoveSystem>();
        _systems.AddIfDoesnNotHas<VerticalMoveLimitSystem>();
    }

    public class Factory : PlaceholderFactory<Pong> { }
}