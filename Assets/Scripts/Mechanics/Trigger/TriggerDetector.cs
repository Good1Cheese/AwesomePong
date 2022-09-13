using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public bool Detected { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        Detected = true;
    }

    private void Update()
    {
        Detected = false;
    }
}