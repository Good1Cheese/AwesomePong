using UnityEngine;

public abstract class Entity_SO : ScriptableObject
{
    public GameObject prefab;
    public Vector3 position;
    public Quaternion rotation;

    public GameObject Spawn()
    {
        return Instantiate(prefab, position, rotation);
    }
}