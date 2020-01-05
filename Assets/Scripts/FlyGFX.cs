using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyGFX : MonoBehaviour
{
    private void Start()
    {
        x_scale = transform.localScale.x;
    }
    void Update()
    {
        if (!gameObject.CompareTag("Cockroach"))
        {
            if (aiPath.desiredVelocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(-x_scale, transform.localScale.y, 1f);
            }
            else if (aiPath.desiredVelocity.x <= -0.01f)
            {
                transform.localScale = new Vector3(x_scale, transform.localScale.y, 1f);
            }
        }
        else
        {
            if (aiPath.desiredVelocity.x >= 0.01f)
            {
                cockroach.transform.localScale = new Vector3(-0.13f, 0.13f, 0.13f);
            }
            else if (aiPath.desiredVelocity.x <= -0.01f)
            {
                cockroach.transform.localScale = new Vector3(0.13f, 0.13f, 0.13f);
            }
        }
        
    }
    private float x_scale;
    public GameObject cockroach;
    public AIPath aiPath;
}
