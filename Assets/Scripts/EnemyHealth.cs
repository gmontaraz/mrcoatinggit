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
            Debug.Log("Colision");
            actual_health--;
            if (actual_health <= 0)
            {
                Destroy(this.gameObject);
                GameObject new_point = Instantiate(point, transform.position, transform.rotation);
                GameObject blood=Instantiate(particles, transform.position, transform.rotation);
                blood.SetActive(true);
                new_point.SetActive(true);
            }
            collision.gameObject.SetActive(false);
        }
    }
    #region variables
    public int actual_health;
    public int max_health;
    public GameObject point;
    public GameObject particles;
    #endregion
}
