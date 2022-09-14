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
            ref InputComponent inputComponent = ref world.Get<InputComponent>(entity);
            ref Moveable moveable = ref world.Get<Moveable>(entity);

            Vector2 input = inputComponent.Main.ReadValue<Vector2>();

            Vector3 vector3Input = new(input.x, 0, input.y);

            moveable.Direction = vector3Input;
        }
    }
}