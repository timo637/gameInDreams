using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStarter2 : MonoBehaviour
{
    public GameObject elevator_ground;

    // Start is called before the first frame update
    void Update()
    {
        elevator_ground.GetComponent<Animator>().Play("Elevator");
    }
}
