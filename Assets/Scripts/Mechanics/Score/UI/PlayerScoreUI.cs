using Leopotam.EcsLite;

public class PlayerScoreUI : EntityScoreUI
{
    protected override EcsFilter GetFilter()
    {
        return _world.Filter<PlayerMarker>().Inc<Scoreable>().End();
    }
}