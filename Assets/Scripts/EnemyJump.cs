using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Jump());
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(2f);
        rb.AddForce(new Vector2(0, forceY));
        //myAnimator.SetBool("cucaSalto", true);
        //myAnimator.SetBool("cucaSalto", false);
        StartCoroutine(Jump());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //myAnimator = GetComponent<Animator>();
    }

    public float forceY = 200f;
    private Rigidbody2D rb;
    //private Animator myAnimator;
}
