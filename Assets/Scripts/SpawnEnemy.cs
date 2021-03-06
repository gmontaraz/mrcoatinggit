﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("Spawn", 2f, Mathf.RoundToInt(Random.Range(6,10)));
    }
    void Update()
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                spawnSpawners.spawns_activated[num_spawn] = false;
                spawnSpawners.num_spawns--;
                coreHealth.Core_Healed(10);
                Destroy(this.gameObject);
                FindObjectOfType<round_manager>().tap_hole();
            }
        }
    }

    private void Spawn()
    {
        Debug.Log("RESTO:" + 6 % 6);
        Debug.Log(array.Length);
        int i_random = Random.Range(0, array.Length);
        enemy = array[i_random];
        if(!(FindObjectOfType<SpawnSpawners>().total % 6f == 0))
        {
            FindObjectOfType<SpawnSpawners>().cockroach_appeared = false;
        }
        if (FindObjectOfType<SpawnSpawners>().total %6f == 0 && FindObjectOfType<SpawnSpawners>().cockroach_appeared == false)
        {
            enemy = array[5]; // cockroach number
            FindObjectOfType<SpawnSpawners>().cockroach_appeared = true;
        }
        else if (enemy.CompareTag("Cockroach"))
        {
            Spawn();
        }

        if (enemy.CompareTag("Spider"))
        {
            if (FindObjectOfType<SpawnSpawners>().spider_count>=4)
            {
                Spawn();
            }
            else
            {
                FindObjectOfType<SpawnSpawners>().spider_count += 1;
                GameObject new_enemy = Instantiate(enemy, transform.position, transform.rotation);
                new_enemy.SetActive(true);
            }
            
        }
        
        //else if (enemy.CompareTag("Cockroach"))
        //{
        //    if (FindObjectOfType<SpawnSpawners>().cockroach_appeared == true)
        //    {
        //        Spawn();
        //    }
        //    else if (Random.Range(0, 100) < 20)
        //    {
        //        FindObjectOfType<SpawnSpawners>().cockroach_appeared = true;
        //        GameObject new_enemy = Instantiate(enemy, transform.position, transform.rotation);
        //        new_enemy.SetActive(true);
        //    }
        //    else
        //    {
        //        Spawn();
        //    }
        //}
        else
        {
            if ((enemy == array[6] || enemy == array[7] )&& Random.Range(0f,100f)>20f)
            {
                Spawn();
            }
            else
            {
                GameObject new_enemy = Instantiate(enemy, transform.position, transform.rotation);
                new_enemy.transform.localScale = enemy.transform.localScale;
                new_enemy.SetActive(true);
            }
            
        }
        
       
    }
    private GameObject enemy;
    public SpawnSpawners spawnSpawners;
    public TextMesh text;
    public CoreHealth coreHealth;
    public Efficiency efficiency;
    public bool delete = false;
    public string text_s;
    public int num_spawn;
    [SerializeField] private GameObject[] array;
}

