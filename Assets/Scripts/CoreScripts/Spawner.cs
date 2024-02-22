using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] [Range(0,3)] protected float max_x_offset_from_zero;
    [SerializeField] protected float ySpawnPosition;
    [SerializeField] protected float reloadTime;
    [SerializeField] protected GameObject[] spawnedPrefabs;
    [SerializeField] [Range(0, 3)] protected float randomTimeOffset;
    float _currentReload = 0;

    void Update()
    {
        _currentReload += Time.deltaTime;
        if (_currentReload > reloadTime)
        {
            _currentReload = 0 + Random.Range(randomTimeOffset * -1, randomTimeOffset);
            SpawnItemAtPosition(getSpawnPosition());
        }
    }

    public virtual void SpawnItemAtPosition(Vector3 position)
    {
        Instantiate(spawnedPrefabs[Random.Range(0, spawnedPrefabs.Length)],position, Quaternion.identity);
    }

    public Vector3 getSpawnPosition()
    {
        return new Vector3(Random.Range(max_x_offset_from_zero * -1, max_x_offset_from_zero), ySpawnPosition);
    }
}
