using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Doublsb.Dialog;

public class NPC : MonoBehaviour
{
    public List<dialogElement> dialog;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<DialogData> GetDialogData()
    {
        List<DialogData> dialogData = new List<DialogData>();

        foreach (dialogElement element in dialog)
        {
            dialogData.Add(new DialogData(element.text, element.speaker, null, true));
        }

        return dialogData;
    }
}

[Serializable]
public struct dialogElement
{
    public string text;
    public string speaker;
    public AudioClip audio;

    public dialogElement(string text, string speaker, AudioClip audio)
    {
        this.text = text;
        this.speaker = speaker;
        this.audio = audio;
    }
}
