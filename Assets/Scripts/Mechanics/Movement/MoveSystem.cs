using Leopotam.EcsLite;
using UnityEngine;

public class MoveSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var inputFilter = world.Filter<Moveable>().End();

        foreach (int entity in inputFilter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);

            var move = moveable.Velocity * moveable.Input;
            moveable.Transform.Translate(move.x, 0, move.y);
        }
    }
}