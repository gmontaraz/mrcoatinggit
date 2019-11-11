using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class groundAI : MonoBehaviour
{

    private void Update()
    {
        if (Physics2D.OverlapCircle(feetPos.position, 0.1f, ground_layer))
        {
            aipath.maxSpeed = 3;
        }
        else
        {
            aipath.maxSpeed = 5;
        }
    }

    public Transform feetPos;
    public LayerMask ground_layer;
    public AIPath aipath;
}
