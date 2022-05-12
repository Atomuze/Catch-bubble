using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    AudioSource AudioSource;
    string SongName = "homura";

    void Start()
    {
        /*
        AudioSource = gameObject.GetComponent<AudioSource>();
        AudioSource = GameObject.Find(SongName).GetComponent<AudioSource>();
        AudioClip audioClip = AudioSource.GetComponent<AudioSource>().clip;
        Debug.Log("music name " + audioClip.name + "\tlength: " + audioClip.length);
        */
    }
}
