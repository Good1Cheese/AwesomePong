﻿using Leopotam.EcsLite;

public class PositionResetSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<Moveable>().Inc<Resetable>().End();

        foreach (int entity in filter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);

            moveable.Transform.position = moveable.StartPosition;
        }
    }
}