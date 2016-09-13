using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

    public GameObject prefabToPool;
    public int poolSize = 10;
    [HideInInspector]
    public List<GameObject> objectPool = new List<GameObject>();
    public List<GameObject> activePooledObjects = new List<GameObject>();

    void Start()
    {
        if (prefabToPool == null)
        {
            Debug.LogError("PrefabToPool is null. Assign reference in Inspector.");
        }

        for (int i = 0; i < poolSize; i++)
        {
            GameObject newGameObject = (GameObject)Instantiate(prefabToPool);
            newGameObject.name = "Enemy_" + i;
            newGameObject.transform.parent = this.transform;
            objectPool.Add(newGameObject);
            newGameObject.SetActive(false);
        }
    }

    public GameObject SpawnObject()
    {
        if (objectPool.Count <= 0)
        {
            Debug.LogWarning("No more objects pooled to spawn.");
        }
        int i = objectPool.Count - 1;
        activePooledObjects.Add(objectPool[i]);
        objectPool.RemoveAt(i);
        activePooledObjects[activePooledObjects.Count - 1].transform.position = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
        activePooledObjects[activePooledObjects.Count - 1].SetActive(true);
        return activePooledObjects[activePooledObjects.Count - 1];
    }
}
