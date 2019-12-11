using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling_sprite : MonoBehaviour
{
    void Update()
    {
        /*
        if (player_pos.position.x > front.transform.position.x)
        {
            
            //prev.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
            prev.transform.position += new Vector3(offset, 0, 0);
            var temp = prev;
            prev = front.gameObject;
            front = temp;
        }
        */
        transform.position += ((lastposx - new Vector3(Camera.main.transform.position.x, 0, 0)) * -speed);
        transform.position += ((lastposy - new Vector3(0, Camera.main.transform.position.y, 0)) * -speed);
        lastposx = new Vector3(Camera.main.transform.position.x, 0, 0);
        lastposy = new Vector3(0, Camera.main.transform.position.y, 0);
    }

    [SerializeField] private float speed;
   // public Transform player_pos;
    private Vector3 lastposx;
    private Vector3 lastposy;
    //[SerializeField] private GameObject prev;
    //[SerializeField] private GameObject front;
    //[SerializeField] private float offset;
    //public Rigidbody2D player_rb;
}
