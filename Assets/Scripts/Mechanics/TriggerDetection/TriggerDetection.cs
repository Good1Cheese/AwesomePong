using System;
using UnityEngine;

public abstract class TriggerDetection : MonoBehaviour
{
    public Action<ObstacleTrigger> Triggered { get; set; }
    public bool Detected { get; set; }
}