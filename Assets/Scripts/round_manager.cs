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
        holes_total = 4+FindObjectOfType<PlayerMovement>().round*2;
        holes_actual = 0;
        holes_text.text = holes_actual + "/" + holes_total;
    }
    public void tap_hole()
    {
        holes_actual++;
        if (holes_actual >= holes_total)
        {
            round_finished = true;
            door.SetActive(true);
        }
        holes_text.text = holes_actual + "/" + holes_total;

    }
    public int holes_total;
    public int holes_actual;
    public bool round_finished=false;
    public Text holes_text;
    public GameObject door;
}
