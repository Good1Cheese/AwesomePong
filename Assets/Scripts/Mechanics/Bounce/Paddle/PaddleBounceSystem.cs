﻿using Leopotam.EcsLite;
using UnityEngine;

public class PaddleBounceSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<Moveable>().Inc<WallTriggeredMarker>().End();

        foreach (int entity in filter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);

            Vector2 direction = moveable.Direction;
            direction.y = -direction.y;

            moveable.Direction = direction;
        }
    }
}