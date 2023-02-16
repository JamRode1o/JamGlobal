using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSounds : MonoBehaviour
{

    public List<AudioClip> walkSounds;

    public AudioSource audioSource;
    
    public int pos;
    // Start is called before the first frame update

    public void Step()
    {
        pos = (int)Mathf.Floor(Random.Range(0, walkSounds.Count));
        audioSource.PlayOneShot(walkSounds[pos]);
    }
}
