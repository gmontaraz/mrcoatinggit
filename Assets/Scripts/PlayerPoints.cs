using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        actual_points = min_points;
        points_text.text = "Points: " + actual_points;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            actual_points += random_points;
            points_text.text = "Points: " + actual_points;
        }
    }
    public int min_points;
    public int random_points = 1;
    public int actual_points;
    [SerializeField] private Text points_text;
}
