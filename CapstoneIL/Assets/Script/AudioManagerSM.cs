using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerSM : MonoBehaviour
{
    [Header("------AUDIO SOURCE-----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------AUDIO CLIP-------------")]
    public AudioClip backsound;
    public AudioClip selectBtn;
    public AudioClip backBtn;
    public AudioClip startGameBtn;

    private void Start()
    {
        musicSource.clip = backsound;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}