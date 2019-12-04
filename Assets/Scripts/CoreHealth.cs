using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreHealth : MonoBehaviour
{
    void Start()
    {
        actual_core_health = actual_core_health = FindObjectOfType<Efficiency>().actual_efficiency;
        HandleBar();
        InvokeRepeating("Hole", 0.01f, 0.01f);
    }
    public void Core_Attacked()
    {
        if (actual_core_health > 0)
        {
            actual_core_health--;
            FindObjectOfType<Efficiency>().Resta_Efficiency(5f);
            HandleBar();
        }
    }

    public void Core_Healed(int i)
    {
        actual_core_health += i;
        FindObjectOfType<Efficiency>().Suma_Efficiency(5f);
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
            
            FindObjectOfType<Efficiency>().Resta_Efficiency((spawnSpawners.num_spawns / 100f));
            actual_core_health = FindObjectOfType<Efficiency>().actual_efficiency;
            HandleBar();
    
        }
    }

    public SpawnSpawners spawnSpawners;
    public float max_core_health;
    public float actual_core_health;
    [SerializeField] private Image contentH;
}
