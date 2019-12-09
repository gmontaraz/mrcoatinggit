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
        foreach(Sound s in sounds)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        if (SceneManager.GetActiveScene().name == "Outdoor")
        {
            Play("Town");
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
        footstep.source.pitch = UnityEngine.Random.Range(0.9f, 1f);
        footstep.source.volume = UnityEngine.Random.Range(0.05f, 0.1f);
        footstep.source.Play();
        
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
    public Sound[] sounds;
    private Sound footstep;

    
}
