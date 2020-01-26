using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial_triggers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == triggers[0])
        {
            warning_text.text = "Jump with Space";
        }
        if (collision.gameObject == triggers[1])
        {
            warning_text.text = "You can use obstacles as platforms to reach high places";
        }
        if (collision.gameObject == triggers[2])
        {
            warning_text.text = "Enter the house";
        }
    }
    public GameObject[] triggers;
    public Text warning_text;

}
