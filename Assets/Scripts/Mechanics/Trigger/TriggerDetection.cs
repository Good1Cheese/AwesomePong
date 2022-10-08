using System;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public Action<ObstacleTrigger> OnTriggerEnter { get; set; }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool hasTrigger = collision.transform.TryGetComponent<ObstacleTrigger>(out var triggerable);

        if (!hasTrigger) { return; }

        OnTriggerEnter?.Invoke(triggerable);
    }
}