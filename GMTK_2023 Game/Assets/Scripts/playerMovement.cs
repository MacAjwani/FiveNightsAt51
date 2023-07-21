using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Boolean selected;
    public float speed;

    private Rigidbody rb;
    private float MoveX;
    private float MoveY;

    public Boolean flip;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        selected = gameObject.GetComponentInParent<SelectManage>().curr_Selected == gameObject.GetComponent<playerSelect>().identifier ? true : false;
        if (selected)
        {
            MoveX = Input.GetAxis("Horizontal");
            MoveY = Input.GetAxis("Vertical");

            /*if(MoveX < 0 && flip)
            {
                gameObject.transform.Rotate(new Vector3(0, 180, 0));
                flip = false;
            }
            else if (MoveX > 0 && !flip)
            {
                gameObject.transform.Rotate(new Vector3(0, 180, 0));
                flip = true;
            }*/

            rb.velocity = new Vector3(speed * MoveX, rb.velocity.y, speed * MoveY);
        }
    }
}
