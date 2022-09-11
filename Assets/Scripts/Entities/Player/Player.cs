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

        PlayerControls controls = new();
        player_SO.inputComponent.Controls = controls;
        controls.Enable();

        _world.Add(entity, player_SO.inputComponent);

        player_SO.moveable.Transform = _gameObject.transform;

        _world.Add(entity, player_SO.moveable);
    }

    protected override void AddSystems()
    {
        _systems.AddIfDoesnNotHas<InputSystem>();
        _systems.AddIfDoesnNotHas<MoveSystem>();
        _systems.AddIfDoesnNotHas<VerticalMoveLimitSystem>();
    }

    public class Factory : PlaceholderFactory<Player> { }
}