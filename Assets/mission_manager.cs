using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mission_manager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        mission_show = false;
        timer = 0;
        text_warning = GameObject.Find("warning"); 
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)&&mission_show)
        {

            timer += Time.deltaTime;
            if (timer > 0.3f)
            {
                timer = 0;
                FindObjectOfType<PlayerMovement>().dialog = false;
                this.gameObject.SetActive(false);
                
                if (actual_mission == 0)
                {
                    text_warning.GetComponent<Text>().text = "FIND THE STONE HOUSE";
                }
                else if (actual_mission == 1)
                {
                    text_warning.GetComponent<Text>().text = "FIND THE BRICK HOUSE";
                }
                else
                {
                    text_warning.GetComponent<Text>().text = "FIND THE WOOD HOUSE";
                }

            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                timer = 0;
            }
        }
    }
    public void new_mission()
    {
        int random_i = Random.Range(0, doors.Length);
        if (random_i != FindObjectOfType<PlayerHealth>().last_mission)
        {
            mission_show = true;
            actual_mission = random_i;
            Debug.Log(random_i);
            doors[random_i].SetActive(true);
            sheet[random_i].SetActive(true);
            FindObjectOfType<PlayerHealth>().last_mission = random_i;
        }
        else
        {
            new_mission();
        }
    }
    public GameObject[] doors;
    public GameObject[] sheet;
    public bool mission_show=false;
    public int actual_mission;
    private float timer = 0;
    
    public GameObject text_warning;
}
