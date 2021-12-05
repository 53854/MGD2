using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Scaling : MonoBehaviour
{
    [Range(0.0f, 3.0f)]
    public float scale = 2.0f;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 10.5f)
        {
            float y_scale = 21f / (transform.position.y + 10.5f);
            transform.localScale = new Vector3(y_scale, y_scale, y_scale) * scale;
        }
    }
}
