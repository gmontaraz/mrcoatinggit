using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("Spawn", 1f, 8f);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && delete)
        {
            spawnSpawners.spawns_activated[num_spawn] = false;
            spawnSpawners.num_spawns--;
            spawnSpawners.num_spawns_aux -= 2;
            if(spawnSpawners.num_spawns_aux < 0)
            {
                spawnSpawners.num_spawns_aux = 0;
            }
            coreHealth.Core_Healed(2);
            Destroy(this.gameObject);
            FindObjectOfType<round_manager>().tap_hole();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text_s = "Pulsa C para reparar";
            text.text = text_s;
            delete = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text_s = "";
            text.text = text_s;
            delete = false;
        }
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
    public SpawnSpawners spawnSpawners;
    public TextMesh text;
    public CoreHealth coreHealth;
    public Efficiency efficiency;
    public bool delete = false;
    public string text_s;
    public int num_spawn;
    [SerializeField] private GameObject[] array;
}

