using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Light spotlight;
    public GameObject[] aliens;

    private GameObject alien;
    private CamController cm;
    private bool isDetecting = true;
    void Start()
    {
        cm = GameObject.Find("CamController").GetComponent<CamController>();
        aliens = cm.aliensList;
    }

    // Update is called once per frame
    void Update()
    {
        /*for (int i = 0; i < aliens.Length; i++) 
        {
            if (aliens[i].GetComponent<playerSelect>().Selected) 
            {
                alien = aliens[i];
                break;
            }
        }*/
        if (alien != null && spotlight.intensity > 0 && isDetecting)
        {
            //Calculates angle between the two
            Vector3 directionToTarget = alien.transform.position - spotlight.transform.position;
            //Checks if angle is smaller than the spotlight angle and if the spotted object is moving
            if ((Vector3.Angle(directionToTarget, spotlight.transform.forward) <= spotlight.spotAngle / 2f) && alien.GetComponent<Rigidbody>().velocity != new Vector3(0,0,0))
            {
                //Triggers AlienSpotted method in CamController script
                isDetecting = false;
                cm.GetComponent<CamController>().AlienSpotted();
            }
            else
            {
                isDetecting = true;
            }
        }
    }
}
