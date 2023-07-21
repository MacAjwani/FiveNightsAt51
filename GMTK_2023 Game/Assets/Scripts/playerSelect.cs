using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSelect : MonoBehaviour
{
    public Boolean Selected;
    public float identifier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            gameObject.GetComponentInParent<SelectManage>().curr_Selected = 0;
        }
    }

    private void OnMouseDown()
    {
        Selected = true;
        gameObject.GetComponentInParent<SelectManage>().curr_Selected = identifier;
    }
}
