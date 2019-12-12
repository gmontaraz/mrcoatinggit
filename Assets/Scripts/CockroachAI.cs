using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;

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

        if (System.Math.Abs(player.transform.position.x - transform.position.x) <= 2 && System.Math.Abs(player.transform.position.y - transform.position.y) <= 2 && !golpeado)
        {
            golpeCucaracha();
            golpeado = true;
            Invoke("activatePathfinding", 2f);
            Invoke("golpeCucarachaCargado", 5f);
        }
        health_bar.fillAmount = health.actual_health / health.max_health;
    }

    void golpeCucaracha()
    {
        
        cucaracha.GetComponent<AIPath>().enabled = false;
        cucaracha.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        Invoke("realizarDaño", 0.8f);
        
        
    }
    void realizarDaño()
    {
        if (player.GetComponent<PlayerMovement>().isGrounded && (System.Math.Abs(player.transform.position.x - transform.position.x) <= 2))
        {
            player.GetComponent<PlayerHealth>().RealizarDaño(3);
        }
        cam_anim.SetTrigger("Shake");
        GameObject stars = Instantiate(attack_particles, new Vector2(transform.position.x, transform.position.y+0.1f), transform.rotation);
        stars.SetActive(true);
        
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
    public EnemyHealth health;
    public Image health_bar;
}
