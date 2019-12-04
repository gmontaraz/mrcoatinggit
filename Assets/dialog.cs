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

    void Start()
    {
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
        if(i<sentences.Length - 1)
        {
            i++;
            text.text = "";
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
        if (Input.GetKeyDown(KeyCode.C)&&text.text==sentences[i])
        {
            NextSentence();
        }
    }
}
