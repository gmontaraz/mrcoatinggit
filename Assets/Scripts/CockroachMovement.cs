using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockroachMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (System.Math.Abs(player.position.x - transform.position.x) < 1 && System.Math.Abs(player.position.y - transform.position.y) < 1)
        {
            followPlayer.enabled = false;
            jumping.enabled = false;
        }
    }

    private cockroach_ai followPlayer;
    private EnemyJump jumping;
    private Transform player;
}
