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
        Nucleo_Verde.SetActive(true);
        Nucleo_Verde_actual = true;
    }
    public void Core_Attacked()
    {
        if (actual_core_health > 0)
        {
            actual_core_health--;
            HealthAnimation();
            FindObjectOfType<Efficiency>().Resta_Efficiency();
            HandleBar();
        }
    }

    public void Core_Healed(int i)
    {
        actual_core_health += i;
        HealthAnimation();
        FindObjectOfType<Efficiency>().Suma_Efficiency();
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
                HealthAnimation();
                FindObjectOfType<Efficiency>().Resta_Efficiency();
                HandleBar();
            }
        }
    }
    public void HealthAnimation()
    {

        if (actual_core_health >= ((2 * max_core_health) / 3))
        {
            if (Nucleo_Verde_actual == false)
            {
                Nucleo_Verde.SetActive(true);
                Nucleo_Naranja.SetActive(false);
                Nucleo_Rojo.SetActive(false);
                Nucleo_Verde_actual = true;
                Nucleo_Naranja_actual = false;
                Nucleo_Rojo_actual = false;
            }
        }

        else if (actual_core_health >= (max_core_health / 3))
        {
            if (Nucleo_Naranja_actual == false)
            {
                Nucleo_Verde.SetActive(false);
                Nucleo_Naranja.SetActive(true);
                Nucleo_Rojo.SetActive(false);
                Nucleo_Verde_actual = false;
                Nucleo_Naranja_actual = true;
                Nucleo_Rojo_actual = false;
            }
        }
        else
        {
            if (Nucleo_Rojo_actual == false)
            {
                Nucleo_Verde.SetActive(false);
                Nucleo_Naranja.SetActive(false);
                Nucleo_Rojo.SetActive(true);
                Nucleo_Verde_actual = false;
                Nucleo_Naranja_actual = false;
                Nucleo_Rojo_actual = true;
            }
        }
    }

    public SpawnSpawners spawnSpawners;
    public float max_core_health;
    public float actual_core_health;
    public GameObject Nucleo_Verde;
    public bool Nucleo_Verde_actual;
    public GameObject Nucleo_Naranja;
    public bool Nucleo_Naranja_actual;
    public GameObject Nucleo_Rojo;
    public bool Nucleo_Rojo_actual;
    [SerializeField] private Image contentH;
}
