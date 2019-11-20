using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cockroach_ai : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        speed = 1f;
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (player.position.x > transform.position.x) // x de personaje > x de cucaracha
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else // x de personaje < x de cucaracha
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }

        //Invoke("Jumping", 3f);
    }

    //void Jumping()
    //{

    //    rb.AddForce(Vector2.up * 100f);
    //    Invoke("GoDown", 3f);
    //}

    //void GoDown()
    //{
    //    rb.AddForce(Vector2.up * 0f);
    //    rb.AddForce(Vector2.down * 100f);
    //}

    // Variables
    public float speed;
    private Transform player;
    //Rigidbody2D rb;
}
