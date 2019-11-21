using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreColision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (coreHealth.actual_core_health > 0)
            {
                coreHealth.Core_Attacked();
            }
        }

    }

    public CoreHealth coreHealth;
}
