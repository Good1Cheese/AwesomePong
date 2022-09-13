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

        pong_SO.moveable.Transform = _gameObject.transform;

        ref Collidable collidable = ref _world.Add<Collidable>(entity);
        collidable.Detector = _gameObject.GetComponent<CollisonDetector>();

        ref Triggerable triggerable = ref _world.Add<Triggerable>(entity);
        triggerable.Detector = _gameObject.GetComponent<TriggerDetector>();
    }

    protected override void AddSystems()
    {
        _systems.AddNewIfDoesnNotHas<PongReflectionSystem>();
        _systems.AddNewIfDoesnNotHas<PongGoalSystem>();
        _systems.AddNewIfDoesnNotHas<MoveSystem>();
    }

    public class Factory : PlaceholderFactory<Pong> { }
}