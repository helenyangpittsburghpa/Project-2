using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracker : MonoBehaviour
{
    public GameObject trackObject;
    
    void Update()
    {
        this.transform.position = new Vector3(trackObject.transform.position.x,100, trackObject.transform.position.z);
    }
}
