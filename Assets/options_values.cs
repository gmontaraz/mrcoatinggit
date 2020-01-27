using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options_values : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public float music_volume;
    public float fx_volume;
    
}
