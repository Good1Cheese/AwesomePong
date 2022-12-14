using UnityEngine;

public abstract class Entity_SO : ScriptableObject
{
    public GameObject prefab;
    public Vector2 startPosition;

    public abstract void Init(GameObject gameObject);
}