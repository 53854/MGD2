using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Doublsb.Dialog;

public class Controller : MonoBehaviour
{
    [Header("Scene Reference")]
    public DialogManager dialogManager;
    public GameObject player;

    [Header("MouseCoords")]
    public Vector3 mousePos;
    public Vector3 mousePosWorld;
    public Vector2 mousePosWorld2D;


    [Header("Movement")]
    [Range(0.0f, 3.0f)]
    public float scale = 2.0f;
    [Range(0.0f, 3.0f)]
    public float speed;
    public bool isMoving;
    public bool isInteracting = false;
    public Vector2 targetPos;

    [Header("Inventory")]
    public bool hasPack = false;
    public bool hasKey = false;


    RaycastHit2D hit;

    // Use this for initialization
    void Start()
    {
        dialogManager.Hide();
    }

    // Update is called once per frame
    void Update()
    {

        player.GetComponent<Animator>().SetBool("isWalking", isMoving);


        Debug.Log(dialogManager.state);

        if (Input.GetMouseButtonDown(0) && dialogManager.state == State.Deactivate)
        {

            mousePos = Input.mousePosition;

            mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);

            mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);
            hit = Physics2D.Raycast(mousePosWorld2D, Vector2.zero);


            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;
                string tag = hitObject.tag;

                // Abfrage ob es der Ground ist
                if (tag == "Ground" && !isMoving)
                {
                    targetPos = hit.point;
                    isMoving = true;
                    isInteracting = false;
                    CheckSpriteFlip();
                }
                // Abfrage ob es der Schlüssel ist
                else if (tag == "Interactable")
                {
                    isInteracting = true;
                }
                else if (tag == "Character")
                {
                    dialogManager.Show(hitObject.GetComponent<NPC>().GetDialogData());
                }
            }
            else
            {
                isInteracting = false;
            }
        }
    
    }

    private void FixedUpdate()
    {
        // Player movement and scaling
        if (isMoving && dialogManager.state == State.Deactivate)
        {
            
            // Scale Player according to y position 
            if (player.transform.position.y < 25)
            {
                float y_scale = 34 / (player.transform.position.y + 17);
                player.transform.localScale = new Vector3(y_scale, y_scale, y_scale);
            }

            // Move Player and flip the visual representation if he is facing left
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, speed);
            CheckSpriteFlip();

            // Stop moving if player is close enough to taget position
            if (player.transform.position.x == targetPos.x && player.transform.position.y == targetPos.y)
            {
                isMoving = false;
            }
        }
    }

    void CheckSpriteFlip()
    {
        if (player.transform.position.x > targetPos.x)
        {
            // Nach links blicken
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            // Nach rechts blicken
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

}