﻿using Leopotam.EcsLite;
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
        _systems.AddNewIfThereIsNot<BorderBounceSystem>();
        _systems.AddNewIfThereIsNot<BounceSoundSystem>();
        _systems.AddNewIfThereIsNot<GateBounceSoundSystem>();
        _systems.AddNewIfThereIsNot<MoveSystem>();
    }

    public class Factory : PlaceholderFactory<Pong> { }
}