using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pack : MonoBehaviour
{

    private void OnMouseDown()
    {
        FindObjectOfType<Controller>().hasPack = true;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Interactable>().outLine.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
