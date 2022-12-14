using Leopotam.EcsLite;
using Zenject;

public class Enemy : SpawnableEntity
{
    public Enemy(Enemy_SO entity_SO, EcsWorld ecsWorld, EcsSystems ecsSystems)
        : base(entity_SO, ecsWorld, ecsSystems)
    {
    }

    protected override void AddComponents()
    {
        int entity = _world.NewEntity();
        var enemy_SO = (Enemy_SO)_entity_SO;

        _world.Add(entity, enemy_SO.pongFollowable);

        _world.Add<EnemyMarker>(entity);
        _world.Add<Scoreable>(entity);
    }

    protected override void AddSystems()
    {
        _systems.AddNewIfThereIsNot<PongFollowSystem>();
    }

    public class Factory : PlaceholderFactory<Enemy> { }
}