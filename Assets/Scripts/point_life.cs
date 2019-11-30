using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point_life : MonoBehaviour
{
    private void Start()
    {
        life_time = 5f;
    }
    void Update()
    {
        if (life_time < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            life_time -= Time.deltaTime;
        }
    }
    private float life_time;
}
