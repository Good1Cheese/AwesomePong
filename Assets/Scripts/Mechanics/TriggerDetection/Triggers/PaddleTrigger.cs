using Leopotam.EcsLite;
using UnityEngine;

public class PaddleTrigger : ObstacleTrigger
{
    public override void Trigger(EcsWorld world, in int entity)
    {
        var marker = new PaddleTriggeredMarker
        {
            Renderer = GetComponent<Renderer>()
        };

        world.Add(entity, marker);
    }
}