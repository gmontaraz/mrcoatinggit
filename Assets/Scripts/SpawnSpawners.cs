﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpawners : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 5f);
    }
    private void Spawn()
    {
        if(num_spawns_aux<=0)
        {
            if (num_spawns < 4)
            {
                random_spawn = Random.Range(0, 6);
                Debug.Log("_-_-_" + random_spawn + "_-_-_");
                if (spawns_activated[random_spawn])
                {
                    Debug.Log("o0o0o" + spawns_activated[random_spawn] + "o0o0o");
                    Spawn();
                }
                else
                {
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
        else
        {
            num_spawns_aux--;
            if(num_spawns_aux < 0)
            {
                num_spawns_aux = 0;
            }
        }
    }

    public GameObject spawn;
    public SpawnEnemy spawnEnemy;
    public Vector2[] spawns = new Vector2[12];
    public bool[] spawns_activated = new bool[12];
    public float time_spawn = 10f;
    public int num_spawns_aux;
    public int num_spawns;
    public int random_spawn;
}
