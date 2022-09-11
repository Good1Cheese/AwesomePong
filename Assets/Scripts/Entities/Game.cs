using Leopotam.EcsLite;
using Zenject;

public class Game : Entity
{
    private Player _player;
    private Enemy _enemy;
    private Pong _pong;

    public Game(EcsWorld ecsWorld, EcsSystems ecsSystems)
        : base(ecsWorld, ecsSystems)
    {
    }

    [Inject]
    public void GetStartEntitiesFactories(Player.Factory playerFactory, Enemy.Factory enemyFactory, Pong.Factory pongFactory)
    {
        _player = playerFactory.Create();
        _enemy = enemyFactory.Create();
        _pong = pongFactory.Create();
    }

    public override void Init()
    {
        _player.Init();
        _enemy.Init();
        _pong.Init();
    }

    public class Factory : PlaceholderFactory<Game> { }
}