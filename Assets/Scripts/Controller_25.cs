using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_25 : MonoBehaviour
{

    Vector3 mousePos;
    public Vector3 worldPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit))
            {
                worldPos = hit.point;
                string name = hit.collider.gameObject.name;
                Debug.Log(name);

                if(name == "Floor"){
                    transform.position = new Vector3(worldPos.x, transform.position.y, worldPos.z);
                }
                
            }
        }
        
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);



    }
}
