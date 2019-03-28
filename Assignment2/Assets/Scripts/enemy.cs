using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody rb;
    public Transform player;
    public int MinDist;
    public int MoveSpeed;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {//Looks at Player
        transform.LookAt(player);
        if (Vector3.Distance(transform.position, player.position) >= MinDist)
        {
            rb.velocity = transform.forward*MoveSpeed;
        }//if more or equal to a certain distance to the player, enemy would move forward
    }
        
}

