using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip KickSound;

    private bool punch;
    public AudioClip PunchSound;
    public AudioClip Punch2Sound;

    public AudioClip KickMissSound;

    private bool punchMiss;
    public AudioClip PunchMissSound;
    public AudioClip PunchMiss2Sound;

    public AudioClip DashSound;






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
                if (punch)
                {
                    audioSource.PlayOneShot(PunchSound);//FALTA
                    punch = !punch;
                }
                else
                {
                    audioSource.PlayOneShot(Punch2Sound);//FALTA
                    punch = !punch;
                }
                break;
            case "KickMiss":
                Debug.Log("Kick Miss Sound");
                audioSource.PlayOneShot(KickMissSound);
                break;
            case "PunchMiss":
                Debug.Log("Kick Miss Sound");
                if (punchMiss)
                {
                    audioSource.PlayOneShot(PunchMissSound);//FALTA
                    punchMiss = !punchMiss;
                }
                else
                {
                    audioSource.PlayOneShot(PunchMiss2Sound);//FALTA
                    punchMiss = !punchMiss;
                }
                break;
            case "Dash":
                Debug.Log("Kick Sound");
                audioSource.PlayOneShot(DashSound);
                break;
        }
    }
}

