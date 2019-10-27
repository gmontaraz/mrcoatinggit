using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        actual_health = max_health;
        health_text.text = "Health: " + actual_health;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            actual_health--;
            health_text.text = "Health: " + actual_health;
            if (actual_health <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    public int max_health;
    public int actual_health;
    [SerializeField] private Text health_text;
}
