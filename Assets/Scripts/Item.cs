using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int Cost;
    public Sprite Sprite;
    public string Name;
    public bool Buy()
    {
        if(Cost <= FindObjectOfType<PlayerPoints>().actual_points)
        {
            FindObjectOfType<PlayerPoints>().actual_points -= Cost;
            this.gameObject.SetActive(false);
            return true;
        }
        else 
        {
            return false;
        }
    }
}
