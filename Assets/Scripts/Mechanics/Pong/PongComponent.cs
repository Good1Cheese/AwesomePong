using System;
using UnityEngine;

[Serializable]
public struct PongComponent
{
    [SerializeField]
    private AudioClip _wallBounceClip;

    [SerializeField]
    private AudioClip _scoreClip;

    public AudioSource AudioSource { get; set; }

    public AudioClip WallBounceClip => _wallBounceClip;
    public AudioClip ScoreClip => _scoreClip;
}