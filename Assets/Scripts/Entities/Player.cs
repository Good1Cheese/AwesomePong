using Leopotam.EcsLite;
using Zenject;

public class Player : SpawnableEntity
{
    public Player(Player_SO entity_SO, EcsWorld ecsWorld, EcsSystems ecsSystems)
        : base(entity_SO, ecsWorld, ecsSystems)
    {
    }

    protected override void AddComponents()
    {
        int entity = _world.NewEntity();
        var entity_SO = (Player_SO)_entity_SO;

        _world.Add(entity, entity_SO.Moveable);
    }

    protected override void AddSystems()
    {
        _systems.Add(new MoveSystem());
    }

    public class Factory : PlaceholderFactory<Player> { }
}