using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public void NewSpawn()
    {
        rb.velocity = new Vector2(transform.right.x, 0.15f) * bullet_speed;
        
        Invoke("Destroy", timelife);
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    [SerializeField] private float bullet_speed;
    [SerializeField] private float timelife;
    [SerializeField] private Rigidbody2D rb;
    public static BulletMovement instance;
}
