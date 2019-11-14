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
    void Update()
    {
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                flash= !flash;
                playerRenderer.enabled = flash;
                flashCounter = flashLength;
            }

            if (invincibilityCounter <= 0)
            {
                playerRenderer.enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (invincibilityCounter <= 0)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                actual_health--;
                HandleBar();
                if (actual_health <= 0)
                {
                    this.gameObject.SetActive(false);
                }
                invincibilityCounter = invincibilityLength;
                flash = false;
                flashCounter = flashLength;
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
                invincibilityCounter = invincibilityLength;
                flash = false;
                
                flashCounter = flashLength;
            }
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
    public float invincibilityLength;
    private float invincibilityCounter;
    public SpriteRenderer playerRenderer;
    private float flashCounter;
    public float flashLength = 0.1f;
    private bool flash;
}
