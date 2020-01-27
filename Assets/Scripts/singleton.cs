using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton : MonoBehaviour
{
    public static GameObject instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
