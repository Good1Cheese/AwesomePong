using Leopotam.EcsLite;
using UnityEngine;

public class MoveSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        EcsFilter filter = world.Filter<Moveable>().End();

        foreach (int entity in filter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);

            moveable.Move = moveable.CurrentVelocity * Time.deltaTime * moveable.Direction;

            moveable.Transform.Translate(moveable.Move);
        }
    }
}