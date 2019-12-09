using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dialog : MonoBehaviour
{
    public Text text;
    public int i;
    public string[] sentences;
    public float typingSpeed;
    public int end;
    public float timer;
    public bool finished;

    public void StartConver()
    {
        timer = 0;
        text.text = "Ignatius: ";
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
            text.text = "Ignatius: ";
            StartCoroutine(Type());
        }
        else
        {
            finished = true;
            text.text = "";
            FindObjectOfType<PlayerMovement>().dialog = false;
            this.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)&&text.text == "Ignatius: "+sentences[i])
        {
            NextSentence();
        }
        
        if (Input.GetKey(KeyCode.X))
        {
            
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                finished = true;
                timer = 0;
                text.text = "";
                FindObjectOfType<PlayerMovement>().dialog = false;
                this.gameObject.SetActive(false);
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                timer = 0;
            }
        }
        
    }
}
