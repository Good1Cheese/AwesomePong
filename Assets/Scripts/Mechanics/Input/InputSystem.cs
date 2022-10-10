using Leopotam.EcsLite;
using UnityEngine;

public class InputSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var filter = world.Filter<Moveable>().Inc<InputComponent>().End();

        foreach (int entity in filter)
        {
            ref var inputComponent = ref world.Get<InputComponent>(entity);
            ref var moveable = ref world.Get<Moveable>(entity);

            Vector2 input = inputComponent.Main.ReadValue<Vector2>();

            moveable.Direction = input;
        }
    }
}