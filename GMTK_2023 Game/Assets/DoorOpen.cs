using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float DoorSpeed;
    public float DoorOpenTime; //Time Door is Open in Secs
    public float dopplganger_id;
    public GameObject light;

    public Boolean open; //pulbic for DEBUG
    private int Internal_ticker = 0;
    // Start is called before the first frame update
    void Start()
    {
        light.GetComponent<Light>().color = Color.cyan;
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            Internal_ticker = 0;
            OpenDoor();
        }
        if(transform.position.y == -3 || !open)
        {
            Internal_ticker++;
            open = false;

            if(Internal_ticker * Time.deltaTime > DoorOpenTime)
            {
                CloseDoor();
            }
        }
    }

    void OpenDoor()
    {
        //Innit State
        transform.position = transform.position + Vector3.down * Time.deltaTime * DoorSpeed;
        light.GetComponent<Light>().color = Color.green;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3, (float)2.45), transform.position.z);

    }

    void CloseDoor()
    {
        //Great Reset (Bugs)
        transform.position = transform.position + Vector3.up * Time.deltaTime * DoorSpeed;
        light.GetComponent<Light>().color = Color.cyan;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3, (float)2.45), transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<playerSelect>().identifier == dopplganger_id)
            {
                open = true;
            }
            else
            {
                light.GetComponent<Light>().color = Color.red;

                light.GetComponent<Light>().color = Color.cyan;
                open = false;
            }
        }
    }
}
