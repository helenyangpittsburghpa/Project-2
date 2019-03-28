using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bludger : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public GameObject player;
    private float startTime,endTime;
 
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.Find("player");
        transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
        startTime = Time.timeSinceLevelLoad;
    }

    private void FixedUpdate()
    {
        movement(speed); 
    }

    public void movement(float sp)
    {
        transform.position += sp * transform.forward;
        Debug.DrawRay(transform.position, transform.forward*10, Color.yellow);
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("obstacle")|| col.gameObject.CompareTag("boundary"))
        {
             gameObject.SetActive(false);
             
        }

    }
}
