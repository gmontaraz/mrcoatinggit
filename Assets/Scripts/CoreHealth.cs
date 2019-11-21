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
            efficiency.Resta_Efficiency();
            HandleBar();
        }
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
                efficiency.Resta_Efficiency();
                HandleBar();
            }
        }
    }

    public SpawnSpawners spawnSpawners;
    public Efficiency efficiency;
    public float max_core_health;
    public float actual_core_health;
    [SerializeField] private Image contentH;
}
