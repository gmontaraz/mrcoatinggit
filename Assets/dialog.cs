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

    void Start()
    {
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
    }
}
