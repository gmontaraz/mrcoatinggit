using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Sound_manager : MonoBehaviour
{
    public void Awake()
    {
        fx_volume = FindObjectOfType<options_values>().fx_volume;
        music_volume = FindObjectOfType<options_values>().music_volume;
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            if (s.name[0] == 'm')
            {
                s.source.volume = s.volume * music_volume;
            }
            else
            {
                s.source.volume = s.volume * fx_volume;
            }

            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        if (SceneManager.GetActiveScene().name == "Outdoor")
        {
            Play("m_Town");
            Play("Rain");
        }
        else if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Play("m_MenuSong");
        }
    }
    public void manage_sounds()
    {
        fx_volume = FindObjectOfType<options_values>().fx_volume;
        music_volume = FindObjectOfType<options_values>().music_volume;
        foreach (Sound s in sounds)
        { 
            if (s.name[0] == 'm')
            {
                s.source.volume = s.volume * music_volume;
            }
            else
            {
                s.source.volume = s.volume * fx_volume;
            }
        }
    }

    public  void Play(string name)
    {
       Sound s= Array.Find(sounds, sound => sound.name == name);
       s.source.Play();
    }
    public void RepeatedSound(string name, float freq)
    {
        footstep = Array.Find(sounds, sound => sound.name == name);
        InvokeRepeating("playrepeatedsound", 0, freq);
    }
    public void StopRepeatedSound()
    {
        CancelInvoke();
    }
    public void playrepeatedsound()
    {
        footstep.source.pitch = UnityEngine.Random.Range(0.8f, 1f);
        footstep.source.volume = UnityEngine.Random.Range(0.2f, 0.3f)*fx_volume;
        footstep.source.Play();
        
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
    public Sound[] sounds;
    private Sound footstep;

    public float music_volume;
    public float fx_volume;
}
