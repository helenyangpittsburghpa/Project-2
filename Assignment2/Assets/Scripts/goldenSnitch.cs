using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldenSnitch : MonoBehaviour
{
    Rigidbody rb;
    public int speed;
   
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(Random.insideUnitSphere * speed);
    }
    //https://answers.unity.com/questions/184903/moving-rigidbodies-at-random.html

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameManager.instance.winGame();
            gameObject.SetActive(false);    
        }
    }
}
