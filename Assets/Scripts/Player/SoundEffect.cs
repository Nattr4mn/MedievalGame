using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource EffectSource;

    public void PlayStepSound()
    {
        EffectSource.PlayOneShot(EffectSource.clip);
    }
}
