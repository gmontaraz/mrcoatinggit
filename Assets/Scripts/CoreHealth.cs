using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreHealth : MonoBehaviour
{
    void Start()
    {
        actual_core_health = max_core_health;
        HandleBar();
        InvokeRepeating("Hole", 10f, 10f);
    }
    public void Core_Attacked()
    {
        if (actual_core_health > 0)
        {
            actual_core_health--;
            FindObjectOfType<Efficiency>().Resta_Efficiency(1);
            HandleBar();
        }
    }

    public void Core_Healed(int i)
    {
        actual_core_health += i;
        FindObjectOfType<Efficiency>().Suma_Efficiency(1.5f);
        FindObjectOfType<Efficiency>().HandleBar();
        if (actual_core_health > max_core_health)
        {
            actual_core_health = max_core_health;
        }
        HandleBar();
    }
    public void HandleBar()
    {
        contentH.fillAmount = actual_core_health / max_core_health;
    }
    public void Hole()
    {
        if (actual_core_health > 0)
        {
            if (spawnSpawners.num_spawns >= 0)
            {
                actual_core_health--;
                FindObjectOfType<Efficiency>().Resta_Efficiency(spawnSpawners.num_spawns);
                HandleBar();
            }
        }
    }

    public SpawnSpawners spawnSpawners;
    public float max_core_health;
    public float actual_core_health;
    [SerializeField] private Image contentH;
}
