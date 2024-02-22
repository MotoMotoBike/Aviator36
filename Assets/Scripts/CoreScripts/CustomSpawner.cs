using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSpawner : Spawner
{
    [SerializeField] [Range(0,100)]byte[] spawnChanse;
    void Start()
    {
        foreach(var chanse in spawnChanse)
        {
            if(chanse > 100)
            {
                throw new Exception("Chanse cant be bigger than 100");
            }
        }
    }

    public override void SpawnItemAtPosition(Vector3 position)
    {
        int spawnObjectID = UnityEngine.Random.Range(0, spawnedPrefabs.Length);
        if(UnityEngine.Random.Range(0,101) <= spawnChanse[spawnObjectID])
        {
            Instantiate(spawnedPrefabs[spawnObjectID], position, Quaternion.identity);
        }
    }
}
