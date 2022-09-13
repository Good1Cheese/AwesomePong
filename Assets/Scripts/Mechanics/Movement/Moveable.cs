using System;
using UnityEngine;

[Serializable]
public struct Moveable
{
    [SerializeField] 
    private float _velocity;

    public Vector3 Move { get; set; }
    public Vector3 Direction { get; set; }
    public Transform Transform { get; set; }

    public float Velocity => _velocity;
}