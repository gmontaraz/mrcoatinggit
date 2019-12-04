using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Efficiency : MonoBehaviour
{
    void Start()
    {
        actual_efficiency = start_efficiency;
        HandleBar();
    }
    
    public void Resta_Efficiency()
    {
        actual_efficiency--;
        HandleBar();
    }
    public void Suma_Efficiency()
    {
        actual_efficiency++;
        if (actual_efficiency > max_efficiency)
        {
            actual_efficiency = max_efficiency;
        }
    }
    private void Update()
    {
        if (actual_efficiency <= 0)
        {
            FindObjectOfType<PlayerHealth>().restart_game();
        }
    }
    public void HandleBar()
    {
        contentP.fillAmount = actual_efficiency / max_efficiency;
    }

    public float max_efficiency;
    public float start_efficiency;
    public float actual_efficiency;
    [SerializeField] private Image contentP;
}
