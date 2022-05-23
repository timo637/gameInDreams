using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public GameObject urata;

    void Update()
    {
        if(Input.GetKey("e"))
        {
            urata.GetComponent<Animator>().Play("door animation");
            urata.GetComponent<Animator>().Play("New State");
        }
    }
}
