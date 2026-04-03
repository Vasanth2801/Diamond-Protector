using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class  ObjectPoolItem
    {
        public string objectTag;
        public GameObject prefab;
        public int size;
    }

    public ObjectPoolItem[] pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(ObjectPoolItem pool in pools)
        {
            Queue<GameObject> obj = new Queue<GameObject>();

            for(int i=0; i< pool.size;i++)
            {
                GameObject objPool = Instantiate(pool.prefab);  
                objPool.SetActive(false);
                obj.Enqueue(objPool);
            }

            poolDictionary.Add(pool.objectTag, obj);
        }
    }

    public GameObject SpawnFromPools(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject objToSpawn = poolDictionary[tag].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }
}