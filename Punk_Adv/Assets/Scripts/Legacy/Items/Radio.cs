using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Radio : MonoBehaviour
{

    AudioSource audioSource;
    DialogManager dialogManager;

    private void Start() {
        dialogManager = FindObjectOfType<DialogManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown() {
        if(!audioSource.mute){
            dialogManager.Show(new DialogData("Der Moderator dieser Radiosendung geht mir echt auf den Sack...", "Protag-Kun", null, true));
            audioSource.mute = true;
        } else {
            dialogManager.Show(new DialogData("Naja, wenn es nichts Besseres gibt...", "Protag-Kun", null, true));
            audioSource.mute = false;
        }
    }
}
