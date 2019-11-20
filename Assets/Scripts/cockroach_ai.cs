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
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (player.position.x > transform.position.x) // x de personaje > x de cucaracha
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            speed = 1f;
        }
        else // x de personaje < x de cucaracha
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            speed = 1f;
        }
    }

    // Variables
    public float speed;
    private Transform player;
}
