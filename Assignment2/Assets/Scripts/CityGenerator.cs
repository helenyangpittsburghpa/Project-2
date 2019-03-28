using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    public GameObject building;
    // Start is called before the first frame update
    void Start()
    {
        int[,] array = new int[25, 25];
        for(int i = 0; i < array.GetLength(0); i++)
        {
            for(int j = 0; j <array.GetLength(1); j++)
            {
                array[i,j] = (int)Random.Range(0,10);
            }
        }


        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                GameObject b = Instantiate(building, transform.position + new Vector3(i*10, array[i,j]/0.4f, j * 10), transform.rotation, transform) as GameObject;
                b.transform.localScale = new Vector3(b.transform.localScale.x, (float)array[i, j] * b.transform.localScale.y, b.transform.localScale.z);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
