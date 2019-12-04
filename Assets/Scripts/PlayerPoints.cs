﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    void Start()
    {
        actual_points = min_points;
        points_text.text = actual_points.ToString("D4");
        InvokeRepeating("Efficiency_Points", 1f, 10f);
    }

    private void Update()
    {

    }

    public void Efficiency_Points()
    {
        if (in_level)
        {
            actual_points += Mathf.RoundToInt(efficiency.actual_efficiency);
            points_text.text = actual_points.ToString("D4");
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            actual_points++;
            points_text.text = actual_points.ToString("D4");
        }
    }

    public Efficiency efficiency;
    public bool in_level;
    public int min_points;
    public int actual_points;
    public float actual_efficiency_aux;
    [SerializeField] private Text points_text;
}
