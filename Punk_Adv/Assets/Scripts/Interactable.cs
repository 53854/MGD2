using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Interactable : MonoBehaviour
{
    public string itemName = "Interactable";
    public string description = "This is an interactable object.";
    public bool canBePickedUp = false;
    public bool canBeUsed = false;
    public bool hasBeenClicked = false;
    public SpriteRenderer outLine = null;
    public Sprite onClickSprite = null;
    public string displayText = "Wow... I wonder what this is...";

    

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


    private void OnMouseEnter() {
        if(outLine != null)
        {
            outLine.color = Color.green;
        }
    }

    private void OnMouseExit() {
        if(outLine != null)
        {
            outLine.color = Color.white;
        }
    }

    private void OnMouseDown() {
        hasBeenClicked = true;
        Debug.Log("clicked: " + itemName);
        if(onClickSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = onClickSprite;
        }
    }

    

}
