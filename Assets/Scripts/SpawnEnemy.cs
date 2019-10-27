using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("Spawn", 1f, 4f);
    }
    private void Spawn()
    {
        GameObject new_enemy = Instantiate(enemy, transform.position, transform.rotation);
        new_enemy.SetActive(true);
    }
    public GameObject enemy;
}

