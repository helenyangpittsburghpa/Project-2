using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed;
    public int RotateSpeed;
    Rigidbody rb;
 
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

 
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(new Vector3(-1f * RotateSpeed * Time.deltaTime, 0f,0f));
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(1f * RotateSpeed * Time.deltaTime, 0f, 0f));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0f, -1f * RotateSpeed * Time.deltaTime, 0f));
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0f, 1f * RotateSpeed * Time.deltaTime, 0f));
        }
       
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(new Vector3(0, 0, 20) * speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            rb.Sleep();
        }//https://answers.unity.com/questions/681363/how-to-stop-applying-force-when-button-is-not-pres.html
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("obstacle") || col.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.minusHealth();
        }
    }
}
