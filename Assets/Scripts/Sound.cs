using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Sound
{
    public float volume;
    public AudioClip clip;

    public float pitch;
    public string name;
    public bool loop;
    [System.NonSerialized] public AudioSource source;
}
