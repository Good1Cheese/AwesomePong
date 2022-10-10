using System;
using UnityEngine;

[Serializable]
public struct VerticalPositionClamp
{
    [SerializeField] private float _clamp;

    public float Clamp => _clamp;
}