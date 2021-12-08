using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip KickSound;
    public AudioClip PunchSound;

    static AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string sound)
    {
        switch (sound)
        {
            case "Kick":
                Debug.Log("Kick Sound");
                audioSource.PlayOneShot(KickSound);
                break;
            case "Punch":
                Debug.Log("Punch Sound");
                audioSource.PlayOneShot(PunchSound);
                break;
        }
    }

}
