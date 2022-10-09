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
        var player_SO = (Player_SO)_entity_SO;

        _world.Add(entity, player_SO.moveable);
        _world.Add(entity, player_SO.moveLimit);
        _world.Add(entity, player_SO.inputComponent);
    }

    protected override void AddSystems()
    {
        _systems.AddNewIfThereIsNot<InputSystem>();
        _systems.AddNewIfThereIsNot<MovementSystem>();
        _systems.AddNewIfThereIsNot<VerticalPositionLimitationSystem>();
    }

    public class Factory : PlaceholderFactory<Player> { }
}