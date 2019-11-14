using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyKiller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] enemies_inside = Physics2D.CircleCastAll(transform.position, 1.5f,Vector2.zero);
        if (Input.GetKeyDown(KeyCode.X) && attack_speed<=0)
        {
            player_animator.SetTrigger("attack");

            int i;
            attack_speed = 0.3f;
            for (i = 0; i < enemies_inside.Length; i++)
            {
                if (enemies_inside[i].collider.CompareTag("Enemy") || enemies_inside[i].collider.CompareTag("Spider"))
                {
                    cam_anim.SetTrigger("Shake");
                    Vector2 angle = enemies_inside[i].collider.gameObject.transform.position - transform.position;
                    angle = angle.normalized;
                    enemies_inside[i].collider.gameObject.GetComponent<AIPath>().enabled = false;
                    enemies_inside[i].collider.gameObject.GetComponent<Rigidbody2D>().AddForce(angle * 500);
                    StartCoroutine(MyFunction(enemies_inside[i].collider.gameObject, 0.1f));
                    enemies_inside[i].collider.gameObject.GetComponent<EnemyHealth>().attacked(1);
                    
                }
            }
        }
        IEnumerator MyFunction(GameObject enemy, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            enemy.GetComponent<AIPath>().enabled = true;
        }
        if (attack_speed > 0)
        {
            attack_speed -= Time.deltaTime;
        }
        
    }
    public Animator cam_anim;
    public Animator player_animator;
    [SerializeField] private float attack_speed;
}
