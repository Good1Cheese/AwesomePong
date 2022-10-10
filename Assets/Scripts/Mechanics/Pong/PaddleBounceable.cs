using System;
using UnityEngine;

[Serializable]
public struct PaddleBounceable
{
    [SerializeField] private float _xDirectionClamp;
    [SerializeField] private float _yDirectionClamp;

    public float XDirectionValue => _xDirectionClamp;
    public float YDirectionClamp => _yDirectionClamp;
}