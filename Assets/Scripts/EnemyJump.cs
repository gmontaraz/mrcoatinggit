using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Jump());
        //forceX = -forceX;
        forceX = 300f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //speed = 1f;
        Vector3 characterScale = transform.localScale;
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(2f);
        //rb.AddForce(new Vector2(0, forceY));
        rb.AddForce(new Vector2(forceX, forceY));
        //myAnimator.SetBool("cucaSalto", true);
        //myAnimator.SetBool("cucaSalto", false);
        StartCoroutine(Jump());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (player.position.x > transform.position.x) // x de personaje > x de cucaracha
        {
            //transform.eulerAngles = new Vector3(0, 0, 0);
            forceX = 300f;
            Vector3 characterScale = transform.localScale;
            characterScale.x = 1;
            //speed = 1f;
            transform.localScale = characterScale;
        }
        else // x de personaje < x de cucaracha
        {
            forceX = -300f;
            //transform.eulerAngles = new Vector3(0, -180, 0);
            Vector3 characterScale = transform.localScale;
            characterScale.x = -1;
            //speed = -1f;
            transform.localScale = characterScale;
        }
        //transform.localScale = characterScale;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //myAnimator = GetComponent<Animator>();
    }

    public float forceX = 300f;
    public float forceY = 600f;
    private Rigidbody2D rb;
    //public float speed;
    private Transform player;
    //private Animator myAnimator;
}
