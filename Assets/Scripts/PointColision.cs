using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointColision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("fafka");
            Destroy(transform.parent.gameObject);
        }
        
    }

}
