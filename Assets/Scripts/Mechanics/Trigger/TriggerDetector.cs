using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public bool Detected { get; private set; }
    public Collider2D Collider { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Detected = true;
        Collider = collision;
    }

    private void Update()
    {
        Detected = false;
    }
}