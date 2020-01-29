using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class insecticide_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        particles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
       
        RaycastHit2D[] enemies_inside = Physics2D.CircleCastAll(transform.position, 1f, Vector2.zero);
        if (Input.GetKeyDown(KeyCode.A))
        {
            cam_anim = GameObject.Find("Main Camera").GetComponent<Animator>();
    
            particles.Play();
            int i;
  
            for (i = 0; i < enemies_inside.Length; i++)
            {
                if (enemies_inside[i].collider.CompareTag("Enemy") || enemies_inside[i].collider.CompareTag("Spider") || enemies_inside[i].collider.CompareTag("Cockroach"))
                {
                    cam_anim.SetTrigger("Shake");
                    Vector2 angle = enemies_inside[i].collider.gameObject.transform.position - transform.position;
                    angle = angle.normalized;
                    enemies_inside[i].collider.gameObject.GetComponent<AIPath>().enabled = false;
                    enemies_inside[i].collider.gameObject.GetComponent<Rigidbody2D>().AddForce(angle * 500);
                    if (enemies_inside[i].collider.CompareTag("Spider"))
                    {
                        if (!enemies_inside[i].collider.gameObject.GetComponent<spider_ai>().web.enabled)
                        {
                            StartCoroutine(MyFunction(enemies_inside[i].collider.gameObject, 0.1f));
                        }
                    }
                    else
                    {
                        StartCoroutine(MyFunction(enemies_inside[i].collider.gameObject, 0.1f));
                    }

                    if (enemies_inside[i].collider.gameObject.GetComponent<EnemyHealth>().poisoned != true)
                    {
                        enemies_inside[i].collider.gameObject.GetComponent<EnemyHealth>().poisoned = true;
                    }
                }

            }
        }
        else
        {
            particles.Stop();
        }
        IEnumerator MyFunction(GameObject enemy, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            if (enemy != null)
            {
                enemy.GetComponent<AIPath>().enabled = true;
            }


        }
    }
    public void Poison(GameObject enemy)
    {
        enemy.GetComponent<EnemyHealth>().actual_health -= 0.5f + (FindObjectOfType<PlayerHealth>().base_dmg / 2);
    }
    public ParticleSystem particles;
    private Animator cam_anim;
}
