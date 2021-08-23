using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public static bool isActive = false;

    public GameObject initTopSide = null;

    public static int lastSideDown = -1;
    public static GameObject lastTopSide = null;

    public static Follow instance;
    private Rigidbody rb;

    private void Start()
    {
        instance = this;
        desiredRot = this.transform.rotation;
        desiredPosition = this.transform.position;
        lastTopSide = initTopSide;
        rb = target.GetComponent<Rigidbody>();
        /*if (Screen.width > Screen.height)
        {
            Screen.orientation = ScreenOrientation.Landscape;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }*/
    }

    Quaternion desiredRot;
    Vector3 desiredPosition;

    public void calculateDesiredPosRot()
    {
        Quaternion desiredRot1 = Quaternion.LookRotation(-Vector3.up, lastTopSide.transform.forward);
        Quaternion desiredRot2 = Quaternion.LookRotation(-Vector3.up, lastTopSide.transform.right);
        Quaternion desiredRot3 = Quaternion.LookRotation(-Vector3.up, -lastTopSide.transform.forward);
        Quaternion desiredRot4 = Quaternion.LookRotation(-Vector3.up, -lastTopSide.transform.right);
        Quaternion desiredRot5 = Quaternion.Angle(transform.rotation, desiredRot1) <= Quaternion.Angle(transform.rotation, desiredRot2) ? desiredRot1 : desiredRot2;
        Quaternion desiredRot6 = Quaternion.Angle(transform.rotation, desiredRot3) <= Quaternion.Angle(transform.rotation, desiredRot4) ? desiredRot3 : desiredRot4;
        desiredRot = Quaternion.Angle(transform.rotation, desiredRot5) <= Quaternion.Angle(transform.rotation, desiredRot6) ? desiredRot5 : desiredRot6;
        desiredPosition = target.transform.position + offset;
        //isActive = true;
    }

    void LateUpdate()
    {
        //if(isActive)
        //{
            Quaternion smoothedRot = Quaternion.Lerp(transform.rotation, desiredRot, smoothSpeed);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            transform.rotation = smoothedRot;
            if (rb.velocity.magnitude == 0.0f)
            {
                //Debug.Log(target.up.ToString());
                //Debug.Log(target.right.ToString());
                //Debug.Log(target.forward.ToString());
                enabled = false;
            }
        //}

        //transform.LookAt(target);
    }
}
