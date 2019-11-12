using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyKiller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] enemies_inside = Physics2D.CircleCastAll(transform.position, 0.75f,Vector2.zero);
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("lol");
            int i;
            
            for (i = 0; i < enemies_inside.Length; i++)
            {
                if (enemies_inside[i].collider.CompareTag("Enemy") || enemies_inside[i].collider.CompareTag("Spider"))
                {
                    Debug.Log("xd");
                    enemies_inside[i].collider.gameObject.GetComponent<EnemyHealth>().attacked();
                    //enemies_inside[i].collider.gameObject.transform.Translat
                    cam_anim.SetTrigger("Shake");
                }
            }
        }
        
    }
    public Animator cam_anim;
}
