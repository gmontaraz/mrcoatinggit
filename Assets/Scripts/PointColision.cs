using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointColision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Ground")
        {
            pointRigidBody = GetComponent<Rigidbody2D>();
            pointRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
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

    Rigidbody2D pointRigidBody;
}
