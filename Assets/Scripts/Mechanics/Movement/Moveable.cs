using System;
using UnityEngine;

[Serializable]
public struct Moveable
{
    [SerializeField] 
    private Vector2 _velocity;

    [SerializeField]
    private Vector2 _verticalMoveLimit;

    public Vector2 Input { get; set; }
    public Transform Transform { get; set; }

    public Vector2 Velocity => _velocity;
    public Vector2 VerticalMoveLimit => _verticalMoveLimit;
}