using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    public Object[] towerObj;

    void Start()
    {
        Object spawnObj = towerObj[Random.Range(0, towerObj.Length)];
        Vector3 pos = transform.position;
        Instantiate(spawnObj, pos, transform.rotation);
    }
}
