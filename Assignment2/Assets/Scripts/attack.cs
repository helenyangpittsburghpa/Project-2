using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    GameManager gameManager;
    public Pooler bludgerPool;
    RaycastHit hit;

    public float lastSpawn = 0;
    public float distance;
    // Start is called before the first frame update
    //when to fire: https://www.youtube.com/watch?v=kOzhE3_P2Mk

    void Update()

    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up), Color.green);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up)*50, out hit, distance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up)*50, Color.red);
            //Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "Player")
            {
                ToFire();
            }
        }
        
    }
     void Awake()
    {
        gameManager = GameManager.instance;
    }
    void ToFire()
    {
        if(bludgerPool == null)
        {
            bludgerPool = gameManager.getBludgerPool();
        }
        GameObject bludgers = bludgerPool.getPooledObject();
        // Debug.Log("hit");
        if ((Time.fixedTime - lastSpawn) > 2f)
        {
            if (bludgers != null && Random.Range(0, 375) < 2)
            {
                Debug.Log("Ouch");
                bludgers.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                bludgers.SetActive(true);
                lastSpawn = Time.fixedTime;
            }
            
            //Instantiate(bludger, transform.position, transform.rotation);
            
        }
    }
}
