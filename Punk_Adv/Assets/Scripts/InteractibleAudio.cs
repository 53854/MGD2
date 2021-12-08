using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractibleAudio : MonoBehaviour
{   
    [Tooltip("The volume which all other sources will be turned down to whilst this one is playing \n 0 = no volume, 1 = full volume")]
    [Range(0, 1)]
    public float LowerVolumeLevel = 1;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    IEnumerator SoloAudio(){
        MuteAll();
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        UnMuteAll();
    }


    void MuteAll(){
        AudioSource[] other = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in other)
        {
            if(a.transform != transform) a.volume *= 0.2f;
        }
    }

    void UnMuteAll(){
        AudioSource[] other = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in other)
        {
            if(a.transform != transform) a.volume /= 0.2f;
        }
    }

    private void OnMouseDown() {
        StartCoroutine(SoloAudio());
    }
}
