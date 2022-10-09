using Leopotam.EcsLite;
using UnityEngine;

public class PaddleTrigger : ObstacleTrigger
{
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public override void Trigger(EcsWorld world, in int entity)
    {
        var marker = new PaddleTriggeredMarker
        {
            Renderer = _renderer
        };

        world.Add(entity, marker);
    }
}