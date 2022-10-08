using Leopotam.EcsLite;
using UnityEngine;

public abstract class SpawnableEntity : Entity
{
    protected Entity_SO _entity_SO;
    protected GameObject _gameObject;

    protected SpawnableEntity(Entity_SO entity_SO, EcsWorld ecsWorld, EcsSystems ecsSystems)
        : base(ecsWorld, ecsSystems)
    {
        _entity_SO = entity_SO;
    }

    public GameObject Spawn()
    {
        return Object.Instantiate(_entity_SO.prefab, _entity_SO.startPosition, _entity_SO.startRotation);
    }

    public override void Init()
    {
        _gameObject = Spawn();

        InitComponents();
        AddComponents();
        AddSystems();
    }

    protected void InitComponents()
    {
        _entity_SO.Init(_gameObject);
    }

    protected abstract void AddComponents();
    protected abstract void AddSystems();
}