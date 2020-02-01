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
        position = new Vector2(this.transform.position.x + 1.2f, this.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            offset = +1.2f;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            offset = -1.2f;
        }
        position = new Vector2(this.transform.position.x + offset, this.transform.position.y);
        RaycastHit2D[] enemies_inside = Physics2D.CircleCastAll(position, 1.2f, Vector2.zero);

        //RaycastHit2D[] enemies_inside = Physics2D.BoxCastAll(new Vector2(this.transform.position.x + 0.4f, this.transform.position.y),new Vector2(0.8f, 0.4f),0,Vector2.zero);

        if (Input.GetKeyDown(KeyCode.A))
        {
            FindObjectOfType<Sound_manager>().Play("WhiteNoise");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            FindObjectOfType<Sound_manager>().Stop("WhiteNoise");
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            
            cam_anim = GameObject.Find("Main Camera").GetComponent<Animator>();
    
            particles.Play();
            int i;
  
            for (i = 0; i < enemies_inside.Length; i++)
            {
                if (enemies_inside[i].collider.CompareTag("Enemy") || enemies_inside[i].collider.CompareTag("Spider") || enemies_inside[i].collider.CompareTag("Cockroach"))
                {
                    /*
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
                    */

     
                    enemies_inside[i].collider.gameObject.GetComponent<EnemyHealth>().startPoison();
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
        enemy.GetComponent<EnemyHealth>().actual_health -= 0.4f + (FindObjectOfType<PlayerHealth>().base_dmg / 5);
    }
    public ParticleSystem particles;
    private Animator cam_anim;
    public Collider2D box;
    public Vector2 position;
    private float offset;
}
