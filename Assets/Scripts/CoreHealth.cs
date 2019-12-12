using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreHealth : MonoBehaviour
{
    void Start()
    {
        actual_core_health = actual_core_health = FindObjectOfType<Efficiency>().actual_efficiency;

        InvokeRepeating("Hole", 0.01f, 0.01f);
    }
    public void Core_Attacked()
    {
        if (actual_core_health > 0)
        {
            actual_core_health--;
            FindObjectOfType<Efficiency>().Resta_Efficiency(5f);

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

    }
    public void Hole()
    {
        if (actual_core_health > 0)
        {
            
            FindObjectOfType<Efficiency>().Resta_Efficiency((spawnSpawners.num_spawns / 150f));
            actual_core_health = FindObjectOfType<Efficiency>().actual_efficiency;
    
        }
    }
    public void HealthAnimation()
    {

        if (actual_core_health >60)
        {
            if (Nucleo_Verde_actual == false)
            {
                humo.startSpeed = 0;
                Nucleo_Verde.SetActive(true);
                Nucleo_Naranja.SetActive(false);
                Nucleo_Rojo.SetActive(false);
                Nucleo_Verde_actual = true;
                Nucleo_Naranja_actual = false;
                Nucleo_Rojo_actual = false;
            }
        }

        else if (actual_core_health <60 && actual_core_health > 20)
        {
            if (Nucleo_Naranja_actual == false)
            {
                humo.startSpeed = 5;
                Nucleo_Verde.SetActive(false);
                Nucleo_Naranja.SetActive(true);
                Nucleo_Rojo.SetActive(false);
                Nucleo_Verde_actual = false;
                Nucleo_Naranja_actual = true;
                Nucleo_Rojo_actual = false;
            }
        }
        else if(actual_core_health < 20)
        {
            if (Nucleo_Rojo_actual == false)
            {
                humo.startSpeed = 10;
                Nucleo_Verde.SetActive(false);
                Nucleo_Naranja.SetActive(false);
                Nucleo_Rojo.SetActive(true);
                Nucleo_Verde_actual = false;
                Nucleo_Naranja_actual = false;
                Nucleo_Rojo_actual = true;
            }
        }
    }
    private void Update()
    {
        HealthAnimation();
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
    public ParticleSystem humo;
}
