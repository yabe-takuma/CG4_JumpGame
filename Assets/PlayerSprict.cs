using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprict : MonoBehaviour
{
    public Rigidbody rb;
    const float moveSpeed = 8.0f;
    const float jumpSpeed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.velocity;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            v.x = moveSpeed;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            v.x = -moveSpeed;
        }
        else
        {
            v.x = 0;
        }
       
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            v.y = jumpSpeed;
        }
        rb.velocity = v;
    }
}
