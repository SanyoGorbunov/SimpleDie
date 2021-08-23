using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public int side;
    public int opositeSide;
    public GameObject opositeSideGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Some shit happened");
        //Debug.Log(this.name);
        Follow.lastSideDown = side;
        Follow.lastTopSide = opositeSideGameObject;
        //Follow.instance.calculateDesiredPosRot();
    }
}
