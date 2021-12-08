using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutz : MonoBehaviour
{

    public GameObject key;

    Controller con;
    BoxCollider2D bc2d;
    Interactable interactable;
    void Start()
    {
        key.SetActive(false);
        con = FindObjectOfType<Controller>();
        bc2d = GetComponent<BoxCollider2D>();
        bc2d.enabled = false;
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        interactable.outLine.enabled = con.hasPack;
        bc2d.enabled = con.hasPack;
    }

    private void OnMouseDown() {
        key.SetActive(true);
    }
}
