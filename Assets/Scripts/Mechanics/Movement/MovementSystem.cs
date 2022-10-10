using Leopotam.EcsLite;
using UnityEngine;

public class MovementSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<Moveable>().End();

        foreach (int entity in filter)
        {
            ref var moveable = ref world.Get<Moveable>(entity);

            moveable.Move = moveable.CurrentVelocity * Time.deltaTime * moveable.Direction;

            moveable.Transform.Translate(moveable.Move);
        }
    }
}