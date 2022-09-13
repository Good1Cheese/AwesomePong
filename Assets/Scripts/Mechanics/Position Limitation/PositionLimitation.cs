﻿using System;
using UnityEngine;

[Serializable]
public struct PositionLimitation
{
    [SerializeField]
    private float _max;

    [SerializeField]
    private float _min;

    public float Max => _max;
    public float Min => _min;
}