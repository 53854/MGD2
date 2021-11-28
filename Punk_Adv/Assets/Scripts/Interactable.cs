using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Interactable : MonoBehaviour
{
    public bool canBePickedUp = false;
    public string displayText = "";

    DialogData _dialogData;

    // Start is called before the first frame update
    void Start()
    {
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
