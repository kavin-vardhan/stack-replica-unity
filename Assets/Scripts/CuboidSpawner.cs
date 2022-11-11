using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboidSpawner : MonoBehaviour
{
    public GameObject SpawnCuboid(GameObject obj)
    {
        Vector3 spawnPos = new Vector3(1000, obj.transform.localScale.y * GameVariables.layerCount, 1000);
        return Instantiate(obj, spawnPos, Quaternion.identity);
    }
}
