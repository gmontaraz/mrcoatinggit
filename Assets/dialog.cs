using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class dialog : MonoBehaviour
{
    public Text text;
    public int i;
    public string[] sentences;
    public float typingSpeed;
    public int end;
    public float timer;
    public bool finished;
    public mission_manager mission_manager;
    
    public void StartConver()
    {
        timer = 0;
        text.text = "";
        StartCoroutine(Type());
    }
    
    IEnumerator Type()
    {
        foreach(char letter in sentences[i].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(i<end)
        {
            i++;
            text.text = "";
            StartCoroutine(Type());
        }
        else
        {
            finished = true;
            text.text = "";
            if (FindObjectOfType<PlayerMovement>().round < 5)
            {
                FindObjectOfType<mission_manager>().new_mission();
            }
            else
            {
                FindObjectOfType<PlayerHealth>().restart_game();
            }
            
            this.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&text.text == sentences[i])
        {
            NextSentence();
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            typingSpeed = 0f;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            typingSpeed = 0.02f;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            
            timer += Time.deltaTime;
            if (timer > 0.2f && FindObjectOfType<PlayerMovement>().round < 2)
            {
                finished = true;
                timer = 0;
                text.text = "";
                
                
               
                FindObjectOfType<mission_manager>().new_mission();
                this.gameObject.SetActive(false);
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                timer = 0;
            }
        }
        
    }
}
