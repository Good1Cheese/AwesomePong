﻿using Leopotam.EcsLite;
using Zenject;

public class Game : Entity
{
    private Player _player;
    private Enemy _enemy;

    public Game(EcsWorld ecsWorld, EcsSystems ecsSystems)
        : base(ecsWorld, ecsSystems)
    {
    }

    [Inject]
    public void GetStartEntitiesFactories(Player.Factory playerFactory, Enemy.Factory enemyFactory)
    {
        _player = playerFactory.Create();
        _enemy = enemyFactory.Create();
    }

    public override void Init()
    {
        _player.Init();
        _enemy.Init();
    }

    public class Factory : PlaceholderFactory<Game> { }
}