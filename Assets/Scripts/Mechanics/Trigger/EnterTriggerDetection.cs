using UnityEngine;

public class EnterTriggerDetection : TriggerDetection
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Detected = collision.transform.TryGetComponent<ObstacleTrigger>(out var triggerable);

        if (!Detected) { return; }

        Triggered?.Invoke(triggerable);
    }

    private void Update()
    {
        Detected = false;
    }
}