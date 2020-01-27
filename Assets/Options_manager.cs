using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options_manager : MonoBehaviour
{
    private void Update()
    {
        FindObjectOfType<options_values>().music_volume = music_slider.value;
        FindObjectOfType<options_values>().fx_volume = fx_slider.value;
        FindObjectOfType<Sound_manager>().manage_sounds();
    }
    public Slider music_slider;
    public Slider fx_slider;
}
