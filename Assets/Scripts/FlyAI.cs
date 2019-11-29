using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        destination.target = GameObject.Find("Player").transform;
    }
    public AIDestinationSetter destination;
}
