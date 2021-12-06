using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Interactable : MonoBehaviour
{   
    
    public List<textLine> lines;
    public string itemName = "Interactable";
    public string description = "This is an interactable object.";
    public bool canBePickedUp = false;
    [HideInInspector]
    public bool canBeUsed = false;
    [HideInInspector]
    public bool hasBeenClicked = false;
    public SpriteRenderer outLine = null;
    public Sprite altSprite = null;

    List<DialogData> _dialogData = new List<DialogData>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (textLine line in lines)
        {
            _dialogData.Add(new DialogData(line.text, line.speaker, null, line.isSkippable));
        }
    }

    public List<DialogData> GetDialogData()
    {
        return _dialogData;
    }

    public Sprite GetSprite()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }


    private void OnMouseEnter()
    {
        if (outLine != null)
        {
            outLine.color = Color.green;
        }
    }

    private void OnMouseExit()
    {
        if (outLine != null)
        {
            outLine.color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        hasBeenClicked = true;
        Debug.Log("clicked: " + itemName);

        if(canBePickedUp){
            // play pickup sound
        }

        if (altSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = altSprite;
        }

        GameObject.FindObjectOfType<DialogManager>().Show(_dialogData);

    }

}

[System.Serializable]
public struct textLine{
    public string text;
    public bool isPlayer ;
    public bool isSkippable ;
    public string speaker ;

    public textLine(string _text ="text to say per line", bool _isPlayer = true, string _speaker = "Only fill if not player",  bool _skippable = true){
        text = _text;
        isPlayer = _isPlayer;
        isSkippable = _skippable;
        speaker = isPlayer? "Protag-Kun" : _speaker;
    }

}