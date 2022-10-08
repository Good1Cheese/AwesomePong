using UnityEngine;

public class StayTriggerDetection : TriggerDetection
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Detected = collision.transform.TryGetComponent<ObstacleTrigger>(out var triggerable);

        if (!Detected) { return; }

        Triggered?.Invoke(triggerable);
    }
}