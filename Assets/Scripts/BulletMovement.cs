using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private void Start()
    {
        if (player_sprite.flipX == true)
        {
            direction = Vector2.left;
        }
        else if (player_sprite.flipX == false)
        {
            direction = Vector2.right;
        }
        Invoke("Destroy", timelife);
       
    }
    void Update()
    {
        this.gameObject.transform.Translate(direction * bullet_speed * Time.deltaTime);
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    [SerializeField] private float bullet_speed;
    [SerializeField] private float timelife;
    public Vector2 direction;
    public SpriteRenderer player_sprite;
}
