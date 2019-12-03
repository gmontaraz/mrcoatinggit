using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", Random.Range(5, 20));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn()
    {
        transform.position = spawns[Mathf.RoundToInt(Random.Range(0,spawns.Length))].position;
    }
    public Transform[] spawns;
}
