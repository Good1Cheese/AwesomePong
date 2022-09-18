using Leopotam.EcsLite;

public class GameResetSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<Moveable>().Inc<GateTriggeredMarker>().End();

        foreach (int entity in filter)
        {
            world.Add<GameStartedMarker>(entity);
        }
    }
}