using Leopotam.EcsLite;

public class GateTrigger : ObstacleTrigger
{
    public override void Trigger(EcsWorld world, in int entity)
    {
        world.Add<GateTriggeredMarker>(entity);
    }
}
