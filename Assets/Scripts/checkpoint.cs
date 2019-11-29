using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GameObject.Find("Player").transform.position = this.gameObject.transform.position;

    }
    public void Spawn()
    {
        if (house)
        {
            transform.position = Vector2.zero;
        }
        GameObject.Find("Player").transform.position = this.gameObject.transform.position;
    }

    public bool house=false;
}
