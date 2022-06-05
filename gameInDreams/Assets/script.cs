using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public GameObject urata;

    void Update()
    {
        if(Input.GetKeyDown("e"))
        {
            urata.GetComponent<Animator>().Play("door animation");
        }
        else if (Input.GetKeyDown("f"))
        {
            urata.GetComponent<Animator>().Play("New State");
        }
    }
}
