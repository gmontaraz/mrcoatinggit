using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        isGrounded= Physics2D.OverlapCircle(feetPos.position, 0.5f, ground);
        Debug.Log(isGrounded);
        ManageJumps();
    }
    private void Move()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");
        vector = new Vector2(moveDirection, 0);
       
        if (rb.velocity.x > 0)
        {
            sprite.flipX = false;
        }
        else if(rb.velocity.x<0)
        {
            sprite.flipX = true;
        }
       
        rb.AddForce(vector * acceleration);
        Vector2 clampedvelocity = rb.velocity;
        clampedvelocity.x=Mathf.Clamp(rb.velocity.x, -playerVelocity, playerVelocity);
        if (moveDirection == 0)
        {
            clampedvelocity.x *= 1f - horizontalDamping;
        }
        rb.velocity = clampedvelocity;
        
    }
    private void ManageJumps()
    {
        if (rememberjump > 0)
        {
            rememberjump -= Time.deltaTime;
        }
        if (remembergrounded > 0)
        {
            remembergrounded -= Time.deltaTime;
        }
        if (isGrounded)
        {
            remembergrounded = remembertime;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rememberjump = remembertime;
        }
        
        if ((rememberjump>0) && (remembergrounded>0))
        {
            rememberjump = 0;
            remembergrounded = 0;
            timeJump = realtimeJump;
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if(Input.GetKey(KeyCode.Z)&& isJumping)
        {
            if (timeJump > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                timeJump -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Z)){
            timeJump = 0;
            isJumping = false;

        }
    }

    #region variables
    private Rigidbody2D rb;
    [Header("Floats")]
    [SerializeField] private float playerVelocity;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float remembertime;
    [SerializeField] private float horizontalDamping;
    private float rememberjump;
    private float remembergrounded;
    private float timeJump;
    private float moveDirection;
    [SerializeField] private float realtimeJump;
    [SerializeField] private float acceleration;
    [SerializeField] private float jumpForce;
    private float attackCoolDown;

    [Header("Transforms")]
    [SerializeField] private Transform feetPos;
    [SerializeField] private Transform weapon;

    [Header("Bools")]
    private bool isJumping;
    private bool isGrounded;
    [Header("Vectors")]
    private Vector2 vector;

    [SerializeField] private SpriteRenderer sprite;

    [Header("Layers")]
    [SerializeField] private LayerMask ground;
    #endregion
}
