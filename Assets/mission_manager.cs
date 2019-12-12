using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission_manager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        mission_show = false;
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C)&&mission_show)
        {

            timer += Time.deltaTime;
            if (timer > 0.2f)
            {
                timer = 0;
                FindObjectOfType<PlayerMovement>().dialog = false;
                this.gameObject.SetActive(false);
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                timer = 0;
            }
        }
    }
    public void new_mission()
    {
        mission_show = true;
        int random_i = Random.Range(0, doors.Length);
        Debug.Log(random_i);
        doors[random_i].SetActive(true);
        sheet[random_i].SetActive(true);
    }
    public GameObject[] doors;
    public GameObject[] sheet;
    public bool mission_show=false;
    private float timer = 0;
}
