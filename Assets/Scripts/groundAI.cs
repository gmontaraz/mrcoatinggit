﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class groundAI : MonoBehaviour
{
    private void Start()
    {
        destination.target = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        if (Physics2D.OverlapCircle(feetPos.position, 0.2f, ground_layer))
        {
            aipath.maxSpeed = 2.5f;
        }
        else
        {
            aipath.maxSpeed = 4;
        }
    }

    public Transform feetPos;
    public LayerMask ground_layer;
    public AIPath aipath;
    public AIDestinationSetter destination;
}
