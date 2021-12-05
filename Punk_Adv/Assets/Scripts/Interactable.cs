using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Interactable : MonoBehaviour
{
    public string name = "Interactable";
    public string description = "This is an interactable object.";
    public bool canBePickedUp = false;
    public bool canBeUsed = false;
    public bool hasBeenClicked = false;
    public string displayText = "";

    

    public Transform interActionPoint;

    DialogData _dialogData;

    // Start is called before the first frame update
    void Start()
    {
        if(interActionPoint == null)
        {
            interActionPoint = transform;
        }
        _dialogData = new DialogData(displayText, "Protag-Kun", null, true);
    }

    public DialogData GetDialogData()
    {
        return _dialogData;
    }

    public Sprite GetSprite(){
        return GetComponent<SpriteRenderer>().sprite;
    }
}
