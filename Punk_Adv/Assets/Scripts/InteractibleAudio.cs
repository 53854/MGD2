using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractibleAudio : MonoBehaviour
{   
    [Tooltip("The volume which all other sources will be turned down to whilst this one is playing \n 0 = no volume, 1 = full volume")]
    [Range(0, 1)]
    public float lowerVolumeLevel = .2f;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }


    IEnumerator SoloAudio(){

        // Turn down all other audio sources
        AudioSource[] other = FindObjectsOfType<AudioSource>();

        // and remember their inital volume
        float[] otherVolumesInital = new float[other.Length];
        for (int i = 0; i < other.Length; i++)
        {
            otherVolumesInital[i] = other[i].volume;
            if(other[i].transform != transform) other[i].volume *= lowerVolumeLevel;
        }

        // Play the audio source
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        

        for (int i = 0; i < other.Length; i++)
        {
            if(other[i].transform != transform) other[i].volume = otherVolumesInital[i];
        }
    }

    private void OnMouseDown() {
        StartCoroutine(SoloAudio());
    }
}
