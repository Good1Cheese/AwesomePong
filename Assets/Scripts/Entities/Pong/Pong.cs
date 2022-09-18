using Leopotam.EcsLite;
using Zenject;
using static UnityEngine.EventSystems.EventTrigger;

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

        _world.Add(entity, pong_SO.moveable);
        _world.Add(entity, pong_SO.pongSounds);
        _world.Add(entity, pong_SO.triggerable);

        _world.Add<GameStartedMarker>(entity);
        _world.Add<PongMarker>(entity);
    }

    protected override void AddSystems()
    {
        _systems.AddNewIfThereIsNot<TriggerDetectorSystem>();
        _systems.AddNewIfThereIsNot<GameResetSystem>();
        _systems.AddNewIfThereIsNot<DirectionResetSystem>();
        _systems.AddNewIfThereIsNot<PositionResetSystem>();
        _systems.AddNewIfThereIsNot<PaddleBounceSystem>();
        _systems.AddNewIfThereIsNot<WallBounceSystem>();
        _systems.AddNewIfThereIsNot<BounceSoundSystem>();
        _systems.AddNewIfThereIsNot<GateBounceSystem>();
        _systems.AddNewIfThereIsNot<GateBounceSoundSystem>();
        _systems.AddNewIfThereIsNot<MoveSystem>();
        _systems.AddNewIfThereIsNot<MarkerDeleteSystem<TriggeredMarker>>();
        _systems.AddNewIfThereIsNot<MarkerDeleteSystem<WallTriggeredMarker>>();
        _systems.AddNewIfThereIsNot<MarkerDeleteSystem<PaddleTriggeredMarker>>();
        _systems.AddNewIfThereIsNot<MarkerDeleteSystem<GateTriggeredMarker>>();
        _systems.AddNewIfThereIsNot<MarkerDeleteSystem<GameStartedMarker>>();
    }

    public class Factory : PlaceholderFactory<Pong> { }
}