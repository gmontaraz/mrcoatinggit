using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyGFX : MonoBehaviour
{
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    public AIPath aiPath;
}
