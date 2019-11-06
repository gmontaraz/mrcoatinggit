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
        Debug.Log(array.Length);
        int i_random = Random.Range(0, array.Length);
        enemy = array[i_random];
        GameObject new_enemy = Instantiate(enemy, transform.position, transform.rotation);
        new_enemy.SetActive(true);
    }
    private GameObject enemy;
    [SerializeField] private GameObject[] array;
}

