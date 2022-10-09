using Leopotam.EcsLite;

public class BorderTrigger : ObstacleTrigger
{
    public override void Trigger(EcsWorld world, in int entity)
    {
        world.Add<BorderTriggeredMarker>(entity);
    }
}
