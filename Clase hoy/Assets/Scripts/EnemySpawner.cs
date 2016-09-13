using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public ObjectPool objectPool;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            objectPool.SpawnObject();
        }
    }
}
