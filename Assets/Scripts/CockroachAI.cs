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
        cam_anim = GameObject.Find("Main Camera").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("PathfindingEnabled", cucaracha.GetComponent<AIPath>().enabled);

        if (System.Math.Abs(player.transform.position.x - transform.position.x) <= 1.15 && System.Math.Abs(player.transform.position.y - transform.position.y) <= 1.15 && !golpeado)
        {
            golpeCucaracha();
            golpeado = true;
        }
    }

    void golpeCucaracha()
    {
        cam_anim.SetTrigger("Shake");
        cucaracha.GetComponent<AIPath>().enabled = false;
        cucaracha.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        if (player.GetComponent<PlayerMovement>().isGrounded)
        {
            player.GetComponent<PlayerHealth>().RealizarDaño(3);
            GameObject stars = Instantiate(attack_particles, transform.position, transform.rotation);
            stars.SetActive(true);
        }
        
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
    public Animator cam_anim;
    public GameObject cucaracha;
    public GameObject player;
    private bool golpeado;
    public Animator animator;
    public GameObject attack_particles;
}
