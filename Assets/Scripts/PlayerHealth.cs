using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        actual_health = max_health;
        golpeado = false;
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
                //playerRenderer.enabled = flash;
                flashCounter = flashLength;
            }

            if (invincibilityCounter <= 0)
            {
                flash = false;
                //playerRenderer.enabled = false;
            }
        }
        if (actual_health < 4)
        {
            low_life_sfx.SetActive(true);
        }
        else
        {
            low_life_sfx.SetActive(false);
        }
        if (flash)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -15);
        }
        else if(!flash){
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        //TE COMENTO ESTO PORQUE DA FALLO HASTA QUE NO LO RESUELVAS, NECESITAS REFERENCIAR LA CUCARACHA DE LA FORMA QUE TE DIJE
        /*
        if (System.Math.Abs(transform.position.x - cucaracha.position.x) <= 1.15 && System.Math.Abs(transform.position.y - cucaracha.position.y) <= 1.15 && !golpeado)
        {
            golpeCucaracha();
            golpeado = true;
        }
        */
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
                    restart_game();
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
                    restart_game();
                }
                Invoke("disablepoison", 5f);
                invincibilityCounter = invincibilityLength;
                flash = false;
                
                flashCounter = flashLength;
            }
        }
        if (collision.collider.CompareTag("medkit"))
        {
            medkit = collision.gameObject;
            medkit.SetActive(false);
            Invoke("RespawnMedkit", Random.Range(5, 20));
            if (actual_health + 4 <= 10)
            {
                actual_health += 4;
                HandleBar();
            }
            else
            {
                actual_health += 10 - actual_health;
                HandleBar();
            }
            
        }
    }
    public void RespawnMedkit()
    {
        medkit.SetActive(true);
        medkit.GetComponent<medkit>().Spawn();
    }
    public void disablepoison()
    {
        player.gameObject.GetComponent<PlayerMovement>().poison = false;
    }

    private void HandleBar(){
        content.fillAmount = actual_health / max_health;
    }
    public void restart_game()
    {
        Destroy(FindObjectOfType<singleton>().gameObject);
        SceneManager.LoadScene("MainMenu");
    }

    void golpeCucaracha()
    {
        objetoCucaracha.GetComponent<AIPath>().enabled = false;
        objetoCucaracha.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        actual_health = actual_health - max_health / 3;
        HandleBar();
        Invoke("activatePathfinding", 2f);
        Invoke("golpeCucarachaCargado", 5f);
    }

    void activatePathfinding()
    {
        objetoCucaracha.GetComponent<AIPath>().enabled = true;
        objetoCucaracha.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    void golpeCucarachaCargado()
    {
        golpeado = false;
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
    public Transform cucaracha;
    public GameObject objetoCucaracha;
    private bool golpeado;
    public GameObject medkit;
    public GameObject low_life_sfx;
}
