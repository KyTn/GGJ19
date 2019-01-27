using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AutoStartMusic : MonoBehaviour
{
    public AudioClip music;

    public AudioSource asource;

    private void Awake()
    {
        asource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        asource.clip = music;

        asource.loop = true;
        asource.Play();
    }

}
