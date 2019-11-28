using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectpool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static objectpool Instance;

    #region Singleton
    private void Awake()
    {
        Instance=this;
    }
    #endregion

    public SpriteRenderer player_sprite;
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i= 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    public void Spawn(string tag, Vector2 position, Quaternion rotation)
    {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.GetComponent<TrailRenderer>().Clear();
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);
        objectToSpawn.GetComponent<BulletMovement>().NewSpawn();

        poolDictionary[tag].Enqueue(objectToSpawn);
    }
}
