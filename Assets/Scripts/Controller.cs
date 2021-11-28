using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Doublsb.Dialog;

public class Controller : MonoBehaviour
{

    public GameObject ui_indicator;

    public DialogManager dialogManager;
    public Animator PlayerAnim;
    public Vector3 mousePos;
    public Camera mainCamera;
    public Vector3 mousePosWorld;   
    public Vector2 mousePosWorld2D;
    RaycastHit2D hit;
    public GameObject player;
    public Vector2 targetPos;
    public float playerOffset;
    public float speed;
    public bool isMoving;

    public bool key = false;
    public int stones = 0;

    // Use this for initialization
    void Start()
    {
        dialogManager.Hide();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerAnim.SetBool("isWalking", isMoving);

        // Wurde die Maustaste gedrückt?
        if (Input.GetMouseButtonDown(0))
        {
            // Maustaste wurde erkannt
            print("Maustaste wurde gedrückt");
            // Mausposition auslesen
            mousePos = Input.mousePosition;
            // Mausposition auf Konsole ausgeben
            print("Screen Space: " + mousePos);
            // Koordinaten von Screen Space nach World Space umwandeln
            mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
            // World Space Koordinaten auf Unity Konsole ausgeben
            print("World Space: " + mousePosWorld);
            // Umwandlung von Vector3 in Vector 2
            mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);

            // Raycast2D => Hit abspeichern
            hit = Physics2D.Raycast(mousePosWorld2D, Vector2.zero);

            // Überprüfe ob hit einen Collider beinhaltet
            if (hit.collider != null)
            {
                print("Objekt mit Collider wurde getroffen!");
                // Ausgabe des getroffenen game objects (name)
                print("Name: " + hit.collider.gameObject.tag);

                // Abfrage ob es der Ground ist
                if (hit.collider.gameObject.tag == "Ground" && !isMoving)
                {
                    // Position des Spielers verändern
                    //player.transform.position = hit.point;
                    targetPos = hit.point + Vector2.up * playerOffset;
                    // isMoving wahr, damit sich Spieler bewegt
                    isMoving = true;
                    // Überprüfe ob Sprite-Flip notwendig ist
                    CheckSpriteFlip();
                }
                // Abfrage ob es der Schlüssel ist
                else if(hit.collider.gameObject.tag == "Collectable")
                {

                    DialogData dialogData = new DialogData("this is a key...", "zombie");
                    dialogManager.Show(dialogData);

                    // Es ist der Schlüssel
                    // Grafik deaktivieren
                    hit.collider.gameObject.SetActive(false);
                    ui_indicator.SetActive(true);
                    // Schlüssel im Skript abspeichern
                    key = true;
                    // Anzahl der Steine um 1 erhöhen
                    stones = stones + 1;
                }
                // Abfrage ob es die Tür ist
                else if(hit.collider.gameObject.tag == "Character")
                {
                    DialogData newText = new DialogData("wow, you found the key", "other");
                    if(!key){
                        newText = new DialogData("you need to find the key first", "other");
                    }
                    dialogManager.Show(newText);
                }
            }
            else
            {
                print("Kein Collider erkannt!");
            }
        }
    }

    private void FixedUpdate()
    {
        // Überprüfe ob Spieler sich bewegt?
        if(isMoving && dialogManager.state == State.Deactivate)
        {
            // Spieler an Zielort befördern
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, speed);
            print("Spieler wird bewegt");

            // Ist der Spieler am Zielort?
            if(player.transform.position.x == targetPos.x && player.transform.position.y == targetPos.y)
            {
                // Spieler am Zielort => isMoving "deaktivieren"
                isMoving = false;
                print("Spieler am Zielort");
            }
        }
    }

    void CheckSpriteFlip()
    {
        if(player.transform.position.x > targetPos.x)
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