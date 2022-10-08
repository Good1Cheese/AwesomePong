using Leopotam.EcsLite;

public class PaddleTrigger : ObstacleTrigger
{
    public override void Trigger(EcsWorld world, in int entity)
    {
        world.Add<PaddleTriggeredMarker>(entity);
    }
}