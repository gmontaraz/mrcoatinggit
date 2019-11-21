using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpawners : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 10f);
    }
    private void Spawn()
    {
        if (num_spawns < 4)
        {
            random_vector_x = Random.Range((-7.7f), (7.7f));
            System.Math.Round(random_vector_x, 1);
            random_vector_y = Random.Range((-4.2f), (3.7f));
            System.Math.Round(random_vector_y, 1);
            if (random_vector_x < 2.5 && random_vector_x > -2.5 && random_vector_y < -1.5)
            {
                Debug.Log("PELIGRO");
                random_vector_x = Random.Range((-7.7f), (7.7f));
                System.Math.Round(random_vector_x, 1);
                random_vector_y = Random.Range((-4.2f), (3.7f));
                System.Math.Round(random_vector_y, 1);
            }
            v_aux = new Vector2((random_vector_x), (random_vector_y));
            Debug.Log(v_aux);
            GameObject new_spawn = Instantiate(spawn, v_aux, transform.rotation);
            new_spawn.SetActive(true);
            num_spawns++;
        }


    }

    public GameObject spawn;
    public Vector2 v_aux;
    public int num_spawns;
    public float random_vector_x;
    public float random_vector_y;
}
