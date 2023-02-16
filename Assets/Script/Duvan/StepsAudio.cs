using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsAudio : MonoBehaviour
{
    [SerializeField] AudioClip[] footStepSounds = default;
    void Step()
    {
     AudioManager.instance.source.PlayOneShot(footStepSounds[Random.Range(0, footStepSounds.Length)]);

    }

}
