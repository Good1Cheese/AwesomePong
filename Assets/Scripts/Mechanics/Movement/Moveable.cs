using System;
using UnityEngine;

[Serializable]
public struct Moveable
{
    [SerializeField]
    private float _velocity;

    public Vector2 Move { get; set; }
    public Vector2 Direction { get; set; }
    public Transform Transform { get; set; }
    public Vector2 StartPosition { get; set; }

    public float Velocity => _velocity;
}