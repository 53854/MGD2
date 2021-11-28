using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Controller_25 : MonoBehaviour
{
    [Range(0, 1)]
    public float moveSpeed = .1f;
    public float goaldDstance = 1f;
    public bool isMoving = false;
    public bool isInteracting = false;

    public DialogManager dialogManager;

    Animator _anim;

    private Vector3 worldPos;
    private Vector3 goalPos;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();

        goalPos = transform.position;

        dialogManager.Hide();        
    }

    // Update is called once per frame
    void Update()
    {
       
          _anim.SetBool("isWalking", isMoving);

        if (Input.GetMouseButtonDown(0) && dialogManager.state == State.Deactivate)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                worldPos = hit.point;
                GameObject hitObject = hit.transform.gameObject;
                string tag = hitObject.tag;
                string name = hitObject.name;
                
                //Debug.Log(name);

                if (name == "Floor")
                {
                    goalPos = new Vector3(worldPos.x, transform.position.y, worldPos.z);
                    /* transform.position = new Vector3(worldPos.x, transform.position.y, worldPos.z); */
                } else if(tag == "Interactable"){
                    dialogManager.Show( hitObject.GetComponent<Interactable>().GetDialogData());
                } else if (tag == "Character"){
                    dialogManager.Show( hitObject.GetComponent<NPC>().GetDialogData());
                }
            }
        }
    }

    private void FixedUpdate() {
        if (Vector3.Distance(transform.position, goalPos) > goaldDstance && dialogManager.state == State.Deactivate)
        {
            isMoving = true;
            transform.position = Vector3.MoveTowards(transform.position, goalPos, moveSpeed);
        }
        else isMoving = false;
    }
}

