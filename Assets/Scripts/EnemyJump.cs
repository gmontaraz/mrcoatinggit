using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Jump());
        forceX = 300f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(1.5f);
        rb.AddForce(new Vector2(forceX, forceY));
        StartCoroutine(Jump());
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > transform.position.x) // x de personaje > x de cucaracha
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            forceX = 300f;
        }
        else // x de personaje < x de cucaracha
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            forceX = -300f;
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public float forceX = 300f;
    public float forceY = 600f;
    private Rigidbody2D rb;
    private Transform player;
}
