using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyKiller : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        ActivateWeapon();
    }
    public void ActivateWeapon()
    {
        cam_anim = GameObject.Find("Main Camera").GetComponent<Animator>();
        activated = true;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D[] enemies_inside = Physics2D.CircleCastAll(transform.position, 1f,Vector2.zero);
        if (Input.GetKeyDown(KeyCode.A) && attack_speed<=0 &&activated)
        {
            cam_anim = GameObject.Find("Main Camera").GetComponent<Animator>();
            player_animator.SetTrigger("attack");

            int i;
            attack_speed = 0.2f;
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
                    enemies_inside[i].collider.gameObject.GetComponent<EnemyHealth>().attacked(2+FindObjectOfType<PlayerHealth>().base_dmg);
                }

            }
        }
        IEnumerator MyFunction(GameObject enemy, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            if (enemy != null)
            {
                enemy.GetComponent<AIPath>().enabled = true;
            }
            
        }
        if (attack_speed > 0)
        {
            attack_speed -= Time.deltaTime;
        }
        
    }
    private Animator cam_anim;
    private bool activated = false;

    public Animator player_animator;
    [SerializeField] private float attack_speed;
}
