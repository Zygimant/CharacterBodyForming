using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAlive : MonoBehaviour
{
    public GameObject MainBody;
    public GameObject LFoot;
    public GameObject RFoot;

    public GameObject LEye;
    public GameObject REye;
    public GameObject LEyePlace;
    public GameObject REyePlace;

    public GameObject LArm;
    public GameObject RArm;
    public GameObject LShoulder;
    public GameObject RShoulder;

    void Update()
    {
        LEye.GetComponent<Transform>().position = LEyePlace.GetComponent<Transform>().position;
        REye.GetComponent<Transform>().position = REyePlace.GetComponent<Transform>().position;



        if ((LArm.transform.localRotation.eulerAngles.z > 340)||(LArm.transform.localRotation.eulerAngles.z > 0 && LArm.transform.localRotation.eulerAngles.z < 90)||(LArm.transform.localRotation.eulerAngles.z < 200 && LArm.transform.localRotation.eulerAngles.z >= 90))
        {
            if (LArm.transform.localRotation.eulerAngles.z > 340)
            {
                LShoulder.transform.localPosition = new Vector3(6.674375f + (0.027f* (LArm.transform.localRotation.eulerAngles.z-340f)), -2.838833f, 0f);
            }
            else if (LArm.transform.localRotation.eulerAngles.z > 0 && LArm.transform.localRotation.eulerAngles.z < 90)
            {
                LShoulder.transform.localPosition = new Vector3(6.674375f + (0.027f * (LArm.transform.localRotation.eulerAngles.z+20f)), -2.838833f, 0f);
            }
            else
            {
                LShoulder.transform.localPosition = new Vector3(6.674375f + (0.027f * -(LArm.transform.localRotation.eulerAngles.z-200f)), -2.838833f, 0f);
            }
        }
        else if(LShoulder.transform.localPosition.x != 6.674375f)
        {
            LShoulder.transform.localPosition = new Vector3(6.674375f, -2.838833f, 0f);
        }

        if ((RArm.transform.localRotation.eulerAngles.z > 340) || (RArm.transform.localRotation.eulerAngles.z > 0 && RArm.transform.localRotation.eulerAngles.z < 90) || (RArm.transform.localRotation.eulerAngles.z < 200 && RArm.transform.localRotation.eulerAngles.z >= 90))
        {
            if (RArm.transform.localRotation.eulerAngles.z > 340)
            {
                RShoulder.transform.localPosition = new Vector3(6.674375f + (0.027f * (RArm.transform.localRotation.eulerAngles.z - 340f)), 0.1005448f, 0f);
            }
            else if (RArm.transform.localRotation.eulerAngles.z > 0 && RArm.transform.localRotation.eulerAngles.z < 90)
            {
                RShoulder.transform.localPosition = new Vector3(6.674375f + (0.027f * (RArm.transform.localRotation.eulerAngles.z + 20f)), 0.1005448f, 0f);
            }
            else
            {
                RShoulder.transform.localPosition = new Vector3(6.674375f + (0.027f * -(RArm.transform.localRotation.eulerAngles.z - 200f)), 0.1005448f, 0f);
            }
        }
        else if (RShoulder.transform.localPosition.x != 6.674375f)
        {
            RShoulder.transform.localPosition = new Vector3(6.674375f, 0.1005448f, 0f);
        }



        if (LFoot.transform.position.y < RFoot.transform.position.y)
        {
            if (LFoot.transform.position.y != 7.8f)
            {
            MainBody.transform.position -= new Vector3(0f, LFoot.transform.position.y + 7.8f, 0f);
            }
        }
        else
        {
            if (RFoot.transform.position.y != 7.8f)
            {
                MainBody.transform.position -= new Vector3(0f, RFoot.transform.position.y + 7.8f, 0f);
            }
        }
    }
}
