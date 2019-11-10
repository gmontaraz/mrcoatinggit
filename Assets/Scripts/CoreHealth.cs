using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        actual_core_health = max_core_health;
    }

    // Update is called once per frame 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            actual_core_health--;
            HandleBar();
            if (actual_core_health <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void HandleBar(){
        content.fillAmount = actual_core_health / max_core_health;
        Debug.Log(actual_core_health / max_core_health); 
    }

    public float max_core_health;
    public float actual_core_health;
    [SerializeField] private float fillAmount;
    [SerializeField] private Image content;
}
