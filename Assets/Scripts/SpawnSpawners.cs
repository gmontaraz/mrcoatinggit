using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpawners : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 4f);
    }
    private void Spawn()
    {
       
        if (!FindObjectOfType<round_manager>().round_finished)
        {
            Debug.Log(FindObjectOfType<round_manager>().round_finished);
            if (num_spawns<4)
            {
                random_spawn = Random.Range(0, 6);
                if (spawns_activated[random_spawn])
                {
                    Spawn();
                }
                else
                {
                    Debug.Log("Spawn");
                    spawns_activated[random_spawn] = true;
                    spawnEnemy.num_spawn = random_spawn;
                    GameObject new_spawn = Instantiate(spawn, spawns[random_spawn], transform.rotation);
                    new_spawn.SetActive(true);
                    num_spawns++;
                    num_spawns_aux += (num_spawns);
                    time_spawn = (10f + (num_spawns * 4));
                }

            }
        }
    }

    public GameObject spawn;
    public SpawnEnemy spawnEnemy;
    public Vector2[] spawns = new Vector2[6];
    public bool[] spawns_activated = new bool[6];
    public int num_spawns;
    public float num_spawns_aux;
    public float time_spawn;
    public int spider_count=0;
    public int random_spawn;
}
