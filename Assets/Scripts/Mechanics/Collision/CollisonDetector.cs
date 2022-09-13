using System;
using UnityEngine;

public class CollisonDetector : MonoBehaviour
{
    public bool Detected { get; private set; }

    private void OnCollisionEnter(Collision collision)
    {
        Detected = true;
    }

    private void Update()
    {
        Detected = false;
    }
}