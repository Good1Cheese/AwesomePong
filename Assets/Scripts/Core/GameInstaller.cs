using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Player_SO _player_SO;
    [SerializeField] private Enemy_SO _enemy_SO;
    [SerializeField] private Pong_SO _pong_SO;

    public override void InstallBindings()
    {
        BindGame();
        BindPlayer();
        BindEnemy();
        BindPong();
    }

    private void BindGame()
    {
        EcsWorld world = new();
        EcsSystems systems = new(world);

        Container.BindInstance(world)
            .AsSingle();

        Container.BindInstance(systems)
            .AsSingle();

        Container.BindFactory<Game, Game.Factory>()
            .AsSingle();
    }

    private void BindPlayer()
    {
        Container.BindInstance(_player_SO)
            .AsSingle();

        Container.BindFactory<Player, Player.Factory>()
            .AsSingle();
    }

    private void BindEnemy()
    {
        Container.BindInstance(_enemy_SO)
            .AsSingle();

        Container.BindFactory<Enemy, Enemy.Factory>()
            .AsSingle();
    }

    private void BindPong()
    {
        Container.BindInstance(_pong_SO)
            .AsSingle();

        Container.BindFactory<Pong, Pong.Factory>()
            .AsSingle();
    }
}