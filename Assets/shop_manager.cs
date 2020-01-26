using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartShop()
    {  
        foreach(Item item in items)
        {
            item.gameObject.SetActive(true);
        }
        i = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && i > 0)
        {
            i--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && i < 3)
        {
            i++;
        }
        Selector.localPosition = new Vector2(pos_x[i], 57);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Buy(i);
        }
        if (Input.GetKey(KeyCode.A))
        { 
           FindObjectOfType<PlayerMovement>().dialog = false;
           this.gameObject.SetActive(false);
        }
    }
    public void Buy(int i)
    {
        Debug.Log("Comprando item " + i);
        if (items[i].Buy())
        {
            Debug.Log(items[i].name);
            switch (items[i].name)
            {
                case "Repair":
                    FindObjectOfType<Efficiency>().Suma_Efficiency(50);
                    break;
                case "HP":
                    FindObjectOfType<PlayerHealth>().max_health += 5;
                    FindObjectOfType<PlayerHealth>().actual_health = FindObjectOfType<PlayerHealth>().max_health;
                    FindObjectOfType<PlayerHealth>().HandleBar();
                    break;
                case "Damage":
                    FindObjectOfType<PlayerHealth>().base_dmg += 1;
                    break;
            }
        }
    }
    private int i;
    public int[] pos_x;
    public RectTransform Selector;
    public Item[] items;
    private float timer;
}
