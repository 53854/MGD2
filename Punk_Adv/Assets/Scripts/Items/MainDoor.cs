using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoor : MonoBehaviour
{
    Controller con;
    BoxCollider2D bc2d;
    void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
        con = FindObjectOfType<Controller>();
    }
}
