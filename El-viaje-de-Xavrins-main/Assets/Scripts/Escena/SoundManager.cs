using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("ListaDeAudios")]
    [SerializeField] private AudioClip[] audios;
    private AudioSource controlAudio;

    private void Awake()
    {
        controlAudio = GetComponent<AudioSource>();
    }

    public void SeleccionDeAudio (int numPista, float volumen)
    {
        controlAudio.PlayOneShot(audios[numPista], volumen);
    }
}
