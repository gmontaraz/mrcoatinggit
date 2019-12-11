using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    void Start()
    {
        actual_points = min_points;
        points_text.text = actual_points.ToString("D4");
    }
    private void Update()
    {
        points_text.text = actual_points.ToString("D4");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            FindObjectOfType<Sound_manager>().Play("Coin");
            actual_points++;
            
            Destroy(collision.transform.parent.gameObject);
            Debug.Log("medkit");
            points_text.text = actual_points.ToString("D4");
        }
    }

    public Efficiency efficiency;
    public bool in_level;
    public int min_points;
    public int actual_points;
    public float actual_efficiency_aux;
    [SerializeField] private Text points_text;
}
