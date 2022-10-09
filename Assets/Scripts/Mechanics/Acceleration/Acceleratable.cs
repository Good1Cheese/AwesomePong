using System;
using UnityEngine;

[Serializable]
public struct Acceleratable
{
    [SerializeField] private float _progress;
    [SerializeField] private float _min;
    [SerializeField] private float _max;

    public float Progress => _progress;
    public float Min => _min;
    public float Max => _max;
}