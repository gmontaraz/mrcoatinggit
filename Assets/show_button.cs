using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_button : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sprite.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sprite.enabled = false;
        }

    }
    public SpriteRenderer sprite;
}
