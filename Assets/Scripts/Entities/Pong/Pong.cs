using Leopotam.EcsLite;
using UnityEngine;
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
        pong_SO.moveable.Direction = new Vector3(0.25f, 0, 1);
        _world.Add(entity, pong_SO.moveable);

        ref PongComponent pongComponent = ref _world.Add(entity, pong_SO.pongComponent);
        pongComponent.AudioSource = _gameObject.GetComponent<AudioSource>();

        ref Collidable collidable = ref _world.Add<Collidable>(entity);
        collidable.CollisionDetector = _gameObject.GetComponent<CollisonDetector>();

        ref Triggerable triggerable = ref _world.Add<Triggerable>(entity);
        triggerable.TriggerDetector = _gameObject.GetComponent<TriggerDetector>();
    }

    protected override void AddSystems()
    {
        _systems.AddNewIfThereIsNot<CollisionDetectSystem>();
        _systems.AddNewIfThereIsNot<TriggerDetectSystem>();
        _systems.AddNewIfThereIsNot<WallBounceSystem>();
        _systems.AddNewIfThereIsNot<WallBounceSoundSystem>();
        _systems.AddNewIfThereIsNot<ScoreSystem>();
        _systems.AddNewIfThereIsNot<ScoreSoundSystem>();
        _systems.AddNewIfThereIsNot<MoveSystem>();
        _systems.AddNewIfThereIsNot<MarkerDeleteSystem<CollidedMarker>>();
        _systems.AddNewIfThereIsNot<MarkerDeleteSystem<TriggeredMarker>>();
    }

    public class Factory : PlaceholderFactory<Pong> { }
}