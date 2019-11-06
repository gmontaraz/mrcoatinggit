using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        movement = new Vector2(1, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(movement * velocity * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(rayorigin_ground.position, Vector2.down, 0.5f,ground);
        RaycastHit2D wallInfo = Physics2D.Raycast(rayorigin_ground.position, Vector2.right, 0.2f, ground);
        if ((Mathf.Abs(transform.position.x-player.position.x)<4f && Mathf.Abs(transform.position.y - player.position.y) < 1f
            )||attack_memory>0)
        {
            if (attack_memory <= 0)
            {
                attack_memory = 2f;
            }
            velocity = attack_velocity;
            if ((player.position.x + 0.1f > transform.position.x) && (transform.position.x > player.position.x - 0.1f))
            {
                moving = false;
            }
            else if (player.position.x > transform.position.x)
            {
                moving = true;
                moving_right = true;
            }
            else if(player.position.x < transform.position.x)
            {
                moving = true;
                moving_right = false;
            }
            
            attack_memory -= Time.deltaTime;
        }
        else if (groundInfo.collider == false || wallInfo.collider == true)
        {
            moving = true;
            velocity = normal_velocity;
            if (moving_right == true)
            {
                moving_right = false;
            }
            else
            {
                moving_right = true;
            }

        }
        if (moving)
        {
            if (moving_right == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (moving_right == false)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        
    }
    private Rigidbody2D rb;
    private bool moving;
    private float attack_memory=0f;
    [SerializeField] private Transform rayorigin_ground;
    [SerializeField] private Transform player;
    [SerializeField] private float velocity;
    [SerializeField] private float normal_velocity;
    [SerializeField] private float attack_velocity;
    [SerializeField] private bool moving_right;
    [SerializeField] private LayerMask ground;
    private Vector2 movement;
}
