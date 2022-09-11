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
    }

    protected override void AddSystems()
    {
    }

    public class Factory : PlaceholderFactory<Enemy> { }
}