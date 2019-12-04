using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;
public class round_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        holes_total = 15;
        holes_actual = 0;
    }
    public void tap_hole()
    {
        holes_actual++;
        if (holes_actual >= holes_total)
        {
            FindObjectOfType<checkpoint>().gameObject.transform.position = new Vector2(FindObjectOfType<PlayerMovement>().s_x, FindObjectOfType<PlayerMovement>().s_y);
            
            
            SceneManager.LoadScene("Outdoor");
            FindObjectOfType<PlayerPoints>().in_level = false;
            FindObjectOfType<checkpoint>().house = false;
            FindObjectOfType<checkpoint>().Spawn();

        }
        holes_text.text = holes_actual + "/" + holes_total;

    }
    public int holes_total;
    public int holes_actual;
    public Text holes_text;
}
