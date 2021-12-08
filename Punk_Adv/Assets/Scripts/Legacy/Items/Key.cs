using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private void OnMouseDown()
    {
        FindObjectOfType<Controller>().hasKey = true;
        GetComponent<BoxCollider2D>().enabled = false;
        
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
