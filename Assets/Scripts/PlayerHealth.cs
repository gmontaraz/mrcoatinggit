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
    }

    // Update is called once per frame 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            actual_health--;
            HandleBar();
            if (actual_health <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.CompareTag("Spider"))
        {
            actual_health--;
            HandleBar();
            player.gameObject.GetComponent<PlayerMovement>().poison = true;
            if (actual_health <= 0)
            {
                this.gameObject.SetActive(false);
            }
            Invoke("disablepoison", 5f);
        }
    }
    public void disablepoison()
    {
        player.gameObject.GetComponent<PlayerMovement>().poison = false;
    }

    private void HandleBar(){
        content.fillAmount = actual_health / max_health;
    }

    public float max_health;
    public float actual_health;
    [SerializeField] private Text health_text;
    [SerializeField] private float fillAmount;
    [SerializeField] private Image content;
    public GameObject player;
}
