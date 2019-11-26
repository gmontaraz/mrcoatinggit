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
    }

    //Update is called once per frame
    void Update()
    {
        if (System.Math.Abs(player.position.x - transform.position.x) < 5 && System.Math.Abs(player.position.y - transform.position.y) < 5)
        {
            Invoke("WaitSeconds", 1f);
            cucaracha.GetComponent<EnemyJump>().enabled = true;
            cucaracha.GetComponent<AIPath>().enabled = false;
        }
        else
        {
            Invoke("WaitSeconds", 1f);
            cucaracha.GetComponent<EnemyJump>().enabled = false;
            cucaracha.GetComponent<AIPath>().enabled = true;
        }

        if (player.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    void WaitSeconds()
    {
        // espera los segundos especificados en el Invoke
        // esto es para arreglar un problema del cambio de movimiento de la cucaracha
    }

    //private bool golpeado = false;
    public GameObject cucaracha;
    //public AIPath aipath;
    //public GameObject player;
    private Transform player;

    //gameObject.GetComponent<NaveMeshAgent>().enabled = false;
}
