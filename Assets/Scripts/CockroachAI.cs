using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CockroachAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        golpeado = false;
        cucaracha = GameObject.FindGameObjectWithTag("Cockroach");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (System.Math.Abs(player.transform.position.x - transform.position.x) <= 1.15 && System.Math.Abs(player.transform.position.y - transform.position.y) <= 1.15 && !golpeado)
        {
            golpeCucaracha();
            golpeado = true;
        }
    }

    void golpeCucaracha()
    {
        cucaracha.GetComponent<AIPath>().enabled = false;
        cucaracha.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        player.GetComponent<PlayerHealth>().RealizarDaño(3);
        Invoke("activatePathfinding", 2f);
        Invoke("golpeCucarachaCargado", 5f);
    }

    void activatePathfinding()
    {
        cucaracha.GetComponent<AIPath>().enabled = true;
        cucaracha.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    void golpeCucarachaCargado()
    {
        golpeado = false;
    }

    public GameObject cucaracha;
    public GameObject player;
    private bool golpeado;
    //public PlayerHealth playerHealth;
}
