using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        actual_health = max_health;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            attacked();
            collision.gameObject.SetActive(false);
        }
    }
    public void attacked()
    {
        actual_health--;
        if (actual_health <= 0)
        {
            Destroy(this.gameObject);
            random_points = Random.Range(min_random_points, max_random_points + 1);
            for (float i = 0; i < random_points; i++)
            {
                createPoint();
            }
            GameObject blood = Instantiate(particles, transform.position, transform.rotation);
            blood.SetActive(true);
        }

    }
    private void createPoint()
    {
        random_vector_x = Random.Range(min_random_vector_x, max_random_vector_x);
        random_vector_y = Random.Range(min_random_vector_y, max_random_vector_y - 0.7f);
        v_aux = new Vector3(random_vector_x, random_vector_y, 0);
        GameObject new_point = Instantiate(point, transform.position, transform.rotation);
        new_point.SetActive(true);
        new_point.transform.Translate(v_aux);
    }
    #region variables
    public int actual_health;
    public int max_health;
    public int random_points;
    public int min_random_points = 3;
    public int max_random_points = 6;
    public Vector3 v_aux;
    public float random_vector_x;
    public float random_vector_y;
    public float min_random_vector_x = -0.05f;
    public float max_random_vector_x = 0.5f;
    public float min_random_vector_y = 0f;
    public float max_random_vector_y = 0.3f;
    public GameObject point;
    public GameObject particles;
    #endregion
}
