using Leopotam.EcsLite;
using UnityEngine;

public class PongGoalSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        EcsWorld world = systems.GetWorld();

        var inputFilter = world.Filter<Moveable>().Inc<Collidable>().End();

        foreach (int entity in inputFilter)
        {
            ref Moveable moveable = ref world.Get<Moveable>(entity);
            ref Triggerable triggerable = ref world.Get<Triggerable>(entity);

            if (triggerable.Detector.Detected)
            {
                Time.timeScale = 0;
                // Activate endgame menu
            }
        }
    }
}

