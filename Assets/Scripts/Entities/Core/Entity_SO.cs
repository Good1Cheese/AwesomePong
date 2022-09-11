using UnityEngine;

public abstract class Entity_SO : ScriptableObject
{
    public GameObject prefab;
    public Vector3 startPosition;
    public Quaternion startRotation;

    public GameObject Spawn()
    {
        return Instantiate(prefab, startPosition, startRotation);
    }
}