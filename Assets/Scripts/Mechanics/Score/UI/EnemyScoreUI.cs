using Leopotam.EcsLite;

public class EnemyScoreUI : EntityScoreUI
{
    protected override EcsFilter GetFilter()
    {
        return _world.Filter<EnemyMarker>().Inc<Scoreable>().End();
    }
}