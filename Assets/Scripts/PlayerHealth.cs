﻿using System.Collections;
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
        last_mission = -1;
        actual_health = max_health;
        base_dmg = 0;
        hp_text.text = actual_health.ToString();
    }

    // Update is called once per frame 
    void Update()
    {
        dmg_text.text = (base_dmg + 1).ToString();
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

    }

    public void RealizarDaño(int daño)
    {
        actual_health-= daño;
        FindObjectOfType<Sound_manager>().Play("Hurt");
        HandleBar();
        if (actual_health <= 0)
        {
            PlayerPrefs.SetInt("record", FindObjectOfType<PlayerMovement>().round);
            PlayerPrefs.Save();
            this.gameObject.SetActive(false);
            restart_game();
        }
        invincibilityCounter = invincibilityLength;
        flash = false;
        flashCounter = flashLength;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (invincibilityCounter <= 0)
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Cockroach"))
            {
                RealizarDaño(2);
            }
            if (collision.gameObject.CompareTag("Spider"))
            {
                RealizarDaño(2);
                player.gameObject.GetComponent<PlayerMovement>().poison = true;
                Invoke("disablepoison", 5f);
            }
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("medkit"))
        {
            Debug.Log("medkit");
            medkit = collision.transform.parent.gameObject;
            medkit.SetActive(false);
            Invoke("RespawnMedkit", Random.Range(5, 20));
            if (actual_health + 4 <= max_health)
            {
                actual_health += 4;
                HandleBar();
            }
            else
            {
                actual_health += max_health - actual_health;
                HandleBar();
            }

        }
    }
    
    public void RespawnMedkit()
    {
        if (medkit != null)
        {
            medkit.SetActive(true);
            medkit.GetComponent<medkit>().Spawn();
        }
        
    }
    public void disablepoison()
    {
        player.gameObject.GetComponent<PlayerMovement>().poison = false;
    }

    public void HandleBar(){
        content.fillAmount = actual_health / max_health;
        hp_text.text = actual_health.ToString();
    }
    public void restart_game()
    {
       
        Destroy(FindObjectOfType<singleton>().gameObject);
        
        SceneManager.LoadScene("Game Over");
    }
    public void finish_tutorial()
    {

        Destroy(FindObjectOfType<singleton>().gameObject);

        SceneManager.LoadScene("MainMenu");
    }

    public float max_health;
    public float actual_health;
    [SerializeField] private Text health_text;
    [SerializeField] private float fillAmount;
    [SerializeField] private Image content;
    public GameObject player;
    public Text hp_text;
    public float invincibilityLength;
    private float invincibilityCounter;
    public SpriteRenderer playerRenderer;
    private float flashCounter;
    public float flashLength = 0.1f;
    private bool flash;
    public GameObject medkit;
    public GameObject low_life_sfx;
    public int base_dmg;
    
    public Text dmg_text;
    public int last_mission;
}
