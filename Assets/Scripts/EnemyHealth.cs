﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        actual_health = max_health+ FindObjectOfType<PlayerMovement>().round;
        poisoned = false;
    }

    private void Update()
    {
        if (poisoned)
        {
            InvokeRepeating("Poison", 0.3f, 0f);
            poisoned = false;
        }
        else
        {
            Invoke("CancelPoison", 1f);
        }
 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            attacked(1+ FindObjectOfType<PlayerHealth>().base_dmg);
            collision.gameObject.SetActive(false);
        }
    }
    public void attacked(int daño)
    {
        actual_health-=daño;
        GameObject blood = Instantiate(particles, transform.position, transform.rotation);
        blood.SetActive(true);
        if (actual_health <= 0)
        {
            if (gameObject.CompareTag("Spider"))
            {
                gameObject.GetComponent<spider_ai>().web_start.GetComponent<swing_manager>().occupied = false;
                FindObjectOfType<SpawnSpawners>().spider_count -= 1;
            }
            Destroy(this.gameObject);
            random_points = Random.Range(min_random_points, max_random_points + 1);
            for (float i = 0; i < random_points; i++)
            {
                createPoint();
            }
            FindObjectOfType<Sound_manager>().Play("EnemyDead");
            
        }
        else
        {
            FindObjectOfType<Sound_manager>().Play("EnemyHit");
        }

    }
    private void createPoint()
    {
        random_vector_x = Random.Range(-1f, 1f);
        random_vector_y = Random.Range(1f, 3f);
        v_aux = new Vector2(random_vector_x, random_vector_y);
        GameObject new_point = Instantiate(point, transform.position, transform.rotation);
        new_point.SetActive(true);
        new_point.GetComponent<Rigidbody2D>().AddForce(v_aux * 80);
    }
    public void Poison(GameObject enemy)
    {
        actual_health -= 0.1f + (FindObjectOfType<PlayerHealth>().base_dmg / 10);
    }
    public void CancelPoison()
    {
        CancelInvoke();
    }
    #region variables
    public float actual_health;
    public float max_health;
    public int random_points;
    public int min_random_points = 5;
    public int max_random_points = 10;
    public Vector3 v_aux;
    public float random_vector_x;
    public float random_vector_y;
    public GameObject point;
    public GameObject particles;
    public bool poisoned;
    #endregion
}
