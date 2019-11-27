using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CockroachMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        core = GameObject.FindGameObjectWithTag("core").GetComponent<Transform>();
        touchingCore = false;
        rb = GetComponent<Rigidbody2D>();
    }

    //Update is called once per frame
    void Update()
    {
        animator.SetFloat("SpeedY", rb.velocity.y);

        if (System.Math.Abs(player.position.x - transform.position.x) < 4 && System.Math.Abs(player.position.y - transform.position.y) < 4 && touchingCore)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            cucaracha.GetComponent<AIPath>().enabled = false;
            cucaracha.GetComponent<EnemyJump>().enabled = true;
            if (player.position.x > transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
        }
        else
        {
            touchingCore = false;
            cucaracha.GetComponent<EnemyJump>().enabled = false;
            cucaracha.GetComponent<AIPath>().enabled = true;
            if (transform.position.x <= core.position.x + 0.5 && transform.position.x >= core.position.x - 0.5 && transform.position.y <= core.position.y + 0.5 && transform.position.y >= core.position.y - 0.5)
            {
                touchingCore = true;
            }
        }
    }
    public GameObject cucaracha;
    private Transform player;
    private Transform core;
    private bool touchingCore;
    public Animator animator;
    private Rigidbody2D rb;
}
