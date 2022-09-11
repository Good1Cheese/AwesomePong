﻿using Leopotam.EcsLite;
using UnityEngine;

public class InputSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var inputFilter = world.Filter<Moveable>().Inc<InputComponent>().End();

        foreach (int entity in inputFilter)
        {
            ref InputComponent inputComponent = ref world.Get<InputComponent>(entity);
            ref Moveable moveable = ref world.Get<Moveable>(entity);

            var input = inputComponent.Main.ReadValue<Vector2>();

            moveable.Input = input;
        }
    }
}