using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coins;

    public AudioSource adsr;
    // Start is called before the first frame update
    void Start()
    {
        coins = Resources.Load<AudioClip>("coin_audio");
        adsr = GetComponent<AudioSource>();
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "coins":
                adsr.clip = coins;
                adsr.PlayOneShot(coins, 0.6f);
                break;
        }
    }
}
