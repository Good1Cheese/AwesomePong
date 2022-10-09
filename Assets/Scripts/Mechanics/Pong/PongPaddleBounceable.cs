using System;
using UnityEngine;

[Serializable]
public struct PongPaddleBounceable
{
    [SerializeField] private float _horizontalClamp;
    [SerializeField] private float _verticalClamp;

    public float HorizontalClamp => _horizontalClamp;
    public float VerticalClamp => _verticalClamp;
}