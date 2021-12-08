using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoor : MonoBehaviour
{
    Controller con;
    BoxCollider2D bc2d;
    void Start()
    {
        con = FindObjectOfType<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        bc2d.enabled = con.hasKey && con.hasPack;
    }
}
