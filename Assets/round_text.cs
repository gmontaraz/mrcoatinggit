using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class round_text : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        text.text = "You defended the town "+PlayerPrefs.GetInt("record")+" round/s";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Text text;
}
