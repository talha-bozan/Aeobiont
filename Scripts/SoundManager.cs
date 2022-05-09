using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip fridgeSound;
    static AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public static void playSound(string soundName)
    {
        fridgeSound = Resources.Load<AudioClip>(soundName);
        audioSrc.PlayOneShot(fridgeSound);
    }
}