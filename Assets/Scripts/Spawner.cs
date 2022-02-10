using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnTime = 5f;
    public Transform prefabToSpawn;
    public Transform spawnedObject;

    private void Start()
    {
        InvokeRepeating("SpawnObject", 0f, _spawnTime);
    }

    public void SpawnObject()
    {
        if (spawnedObject != null) return;

        Transform prefab = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        spawnedObject = prefab;
    }
}
