using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Interactable : MonoBehaviour
{

    public List<textLine> lines;
    public List<textLine> alt_lines;
    public List<textLine> playerHasPack_lines;
    public List<textLine> alt_playerHasPack_lines;
    public List<textLine> playerHasKey_lines;
    public List<textLine> alt_playerHasKey_lines;
    public string itemName = "Interactable";
    public string description = "This is an interactable object.";

    public bool requiresPack = false;
    public bool requiresKey = false;

    public bool canBePickedUp = false;
    [HideInInspector]
    public bool canBeUsed = false;
    [HideInInspector]
    public bool hasBeenClicked = false;
    public bool hasBeenClickedWithPack = false;
    public bool hasBeenClickedWithKey = false;
    public SpriteRenderer outLine = null;
    public Sprite altSprite = null;

    Controller con;
    DialogManager dm;
    Color initColour;
    List<DialogData> _dialogData = new List<DialogData>();

    // Start is called before the first frame update
    void Start()
    {

        con = FindObjectOfType<Controller>();
        dm = FindObjectOfType<DialogManager>();

        if (outLine != null) { initColour = outLine.color; }

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
            outLine.color = initColour;
        }
    }

    private void OnMouseDown()
    {
        if (canBePickedUp)
        {
            // play pickup sound
        }

        if (altSprite != null)
        {
            if(requiresKey){if(!con.hasKey) return;}
            if(requiresPack){if(!con.hasPack) return;}
            GetComponent<SpriteRenderer>().sprite = altSprite;
        }

        var dialog = new List<DialogData>();

        if (dialog.Count > 0) dialog.Clear();
        else if (playerHasKey_lines.Count > 0 && con.hasKey)
        {
            if (alt_playerHasKey_lines.Count == 0) alt_playerHasKey_lines = playerHasKey_lines;

            List<textLine> temp = hasBeenClickedWithKey ? alt_playerHasKey_lines : playerHasKey_lines;

            foreach (textLine line in temp)
            {
                dialog.Add(new DialogData(line.text, line.speaker, null, line.isSkippable));
            }
        }
        else if (playerHasPack_lines.Count > 0 && con.hasPack)
        {
            if (alt_playerHasPack_lines.Count == 0) alt_playerHasPack_lines = playerHasPack_lines;

            List<textLine> temp = hasBeenClickedWithPack ? alt_playerHasPack_lines : playerHasPack_lines;

            foreach (textLine line in temp)
            {
                dialog.Add(new DialogData(line.text, line.speaker, null, line.isSkippable));
            }
        }
        
        else
        {

            if (alt_lines.Count == 0) alt_lines = lines;

            List<textLine> temp = hasBeenClicked ? alt_lines : lines;

            foreach (textLine line in temp)
            {
                dialog.Add(new DialogData(line.text, line.speaker, null, line.isSkippable));
            }
        }

        if (dm.state == State.Deactivate && dialog.Count > 0) dm.Show(dialog);
        hasBeenClicked = true;
        if(con.hasPack) hasBeenClickedWithPack = true;
        if(con.hasKey) hasBeenClickedWithKey = true;
    }

}

[System.Serializable]
public struct textLine
{
    public string text;
    public bool isPlayer;
    public bool isSkippable;
    public string speaker;

    public textLine(string _text = "text to say per line", bool _isPlayer = true, string _speaker = "Only fill if not player", bool _skippable = true)
    {
        text = _text;
        isPlayer = _isPlayer;
        isSkippable = _skippable;
        speaker = isPlayer ? "Protag-Kun" : _speaker;
    }

}