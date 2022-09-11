using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public abstract class SpawnableEntity : Entity
{
    protected Entity_SO _entity_SO;
    protected GameObject _gameObject;

    protected SpawnableEntity(Entity_SO entity_SO, EcsWorld ecsWorld, EcsSystems ecsSystems)
        : base(ecsWorld, ecsSystems)
    {
        _entity_SO = entity_SO;
    }

    public override void Init()
    {
        _gameObject = _entity_SO.Spawn();

        AddComponents();
        AddSystems();
    }

    protected abstract void AddComponents();
    protected abstract void AddSystems();
}