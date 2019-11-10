using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointColision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destruye el punto si lo toca un untagged, sino le atraviesa
        if (collision.gameObject.tag == "Untagged")
        {
            Debug.Log("Colision point ");
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
