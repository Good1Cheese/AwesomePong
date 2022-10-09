using Leopotam.EcsLite;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.Timeline;

public class GateTrigger : ObstacleTrigger
{
    [SerializeField] private bool _isPlayerGate;

    public override void Trigger(EcsWorld world, in int entity)
    {
        EcsFilter filter = _isPlayerGate 
            ? world.Filter<EnemyMarker>().End()
            : world.Filter<PlayerMarker>().End();

        foreach (int scoreEntity in filter)
        {
            world.Add<ScoreMarker>(scoreEntity);
        }

        world.Add<GateTriggeredMarker>(entity);
    }
}
