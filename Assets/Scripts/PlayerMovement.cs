using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        animator.SetFloat("player_velocity", rb.velocity.magnitude);
        animator.SetFloat("y_velocity", rb.velocity.y);
        animator.SetBool("grounded", isGrounded);
        if (poison)
        {
            sprite.color = new Color(0.5f, 1, 0.5f);
            playerVelocity = 2;
            particles.SetActive(true);
        }
        else
        {
            sprite.color = Color.white;
            playerVelocity = playerVelocityreal;
            particles.SetActive(false);
        }
        if(dialog)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            Move();
            ManageJumps();
        }
        
        isGrounded = Physics2D.OverlapCircle(feetPos.position, 0.1f, ground);
        touchingHead = Physics2D.OverlapCircle(feetPos.position, 0.1f, ground);
        if (Mathf.Abs(rb.velocity.x) > 0.1)
        {
            if (!walking && isGrounded)
            {
                walking = true;
                sounds.RepeatedSound("Walk", 0.3f);

            }
            else if(!isGrounded)
            {
                walking = false;
                sounds.StopRepeatedSound();
            }
        }
        else
        {
            walking = false;
            sounds.StopRepeatedSound();
        }

    }
    private void Walk()
    {
        
    }
    private void Move()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");
        vector = new Vector2(moveDirection, 0);
       
        if (Input.GetKey(KeyCode.RightArrow))
        {
           
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {

            transform.eulerAngles = new Vector3(0, 180, 0);
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("stone_door"))
        {
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                playerPoints.in_level = true;
                Debug.Log("door");
                s_x = this.gameObject.transform.position.x;
                
                s_y = this.gameObject.transform.position.y;
                sounds.Stop("Town");
                sounds.Stop("Rain");
                sounds.Play("Main");

                //SceneManager.LoadScene("StoneHouse");
                SceneManager.LoadScene("CockroachFixed");
                FindObjectOfType<checkpoint>().house = true;
                FindObjectOfType<checkpoint>().Spawn();

                Debug.Log(weapons.Length);
                weapons[Random.Range(0, weapons.Length)].SetActive(true);
            }
        }
        if (collision.gameObject.CompareTag("brick_door"))
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                playerPoints.in_level = true;
                Debug.Log("door");
                s_x = this.gameObject.transform.position.x;

                s_y = this.gameObject.transform.position.y;
                sounds.Stop("Town");
                sounds.Stop("Rain");
                sounds.Play("Main");

                SceneManager.LoadScene("BrickHouse");
                FindObjectOfType<checkpoint>().house = true;
                FindObjectOfType<checkpoint>().Spawn();

                Debug.Log(weapons.Length);
                weapons[Random.Range(0, weapons.Length)].SetActive(true);
            }
        }
        if (collision.gameObject.CompareTag("wood_door"))
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                playerPoints.in_level = true;
                Debug.Log("door");
                s_x = this.gameObject.transform.position.x;

                s_y = this.gameObject.transform.position.y;
                sounds.Stop("Town");
                sounds.Stop("Rain");
                sounds.Play("Main");

                SceneManager.LoadScene("WoodHouse");
                FindObjectOfType<checkpoint>().house = true;
                FindObjectOfType<checkpoint>().Spawn();

                Debug.Log(weapons.Length);
                weapons[Random.Range(0, weapons.Length)].SetActive(true);
            }
        }
        if (collision.gameObject.CompareTag("door"))
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                sounds.Play("Town");
                sounds.Play("Rain");
                sounds.Stop("Main");
                FindObjectOfType<checkpoint>().gameObject.transform.position = new Vector2(FindObjectOfType<PlayerMovement>().s_x, FindObjectOfType<PlayerMovement>().s_y);

                foreach (GameObject weapon in FindObjectOfType<PlayerMovement>().weapons)
                {
                    weapon.SetActive(false);
                }
                round += 1;

                SceneManager.LoadScene("Outdoor");
                FindObjectOfType<checkpoint>().house = false;
                FindObjectOfType<checkpoint>().Spawn();
                dialog_manager.GetComponent<dialog>().finished = false;
            }
        }
        if (collision.gameObject.CompareTag("npc")&&dialog==false && Input.GetKeyDown(KeyCode.D))
        {
            dialog = true;
            Debug.Log("empezar dialogo");
            if (round == 1 && !dialog_manager.GetComponent<dialog>().finished)
            {
                
                dialog_manager.GetComponent<dialog>().i = 0;
                dialog_manager.GetComponent<dialog>().end= 18;
                dialog_manager.SetActive(true);
                dialog_manager.GetComponent<dialog>().StartConver();
            }

            else if(round<5 && !dialog_manager.GetComponent<dialog>().finished)
            {

                    dialog_manager.GetComponent<dialog>().i = 19;
                    dialog_manager.GetComponent<dialog>().end = 21;
                    dialog_manager.SetActive(true);
                    dialog_manager.GetComponent<dialog>().StartConver();
            }
            else if(round==5 && !dialog_manager.GetComponent<dialog>().finished)
            {
                dialog_manager.GetComponent<dialog>().i = 23;
                dialog_manager.GetComponent<dialog>().end = 25;
                dialog_manager.SetActive(true);
                dialog_manager.GetComponent<dialog>().StartConver();
            }
            else
            {
                shop.SetActive(true);
                shop.GetComponent<shop_manager>().StartShop();
            }



        }
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jump");
            walking = false;
            
            
            rememberjump = remembertime;
           
        }
        
        if ((rememberjump>0) && (remembergrounded>0))
        {
            sounds.Play("Jump");
            walking = false;
            rememberjump = 0;
            remembergrounded = 0;
            timeJump = realtimeJump;
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if(Input.GetKey(KeyCode.Space)&& isJumping)
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
        else if (Input.GetKeyUp(KeyCode.Space)||touchingHead){
            timeJump = 0;
            isJumping = false;

        }
    }

    #region variables
    public float s_x;
    public float s_y;
    private Rigidbody2D rb;
    [Header("Floats")]
    [SerializeField] private float playerVelocity;
    [SerializeField] private float playerVelocityreal;
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
    public PlayerPoints playerPoints;
    [Header("Transforms")]
    [SerializeField] private Transform feetPos;
    [SerializeField] private Transform weapon;

    [Header("Bools")]
    private bool isJumping;
    private bool touchingHead;
    public bool isGrounded;
    public bool poison;
    [Header("Vectors")]
    private Vector2 vector;
    
    [SerializeField] private SpriteRenderer sprite;
    
    [Header("Layers")]
    [SerializeField] private LayerMask ground;
    public Animator animator;
    public GameObject particles;
    public GameObject[] weapons;
    public int round=1;
    public bool dialog = false;
    public GameObject dialog_manager;
    public GameObject shop;
    public Sound_manager sounds;
    public bool walking;
    #endregion
}
