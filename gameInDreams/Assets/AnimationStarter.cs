using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStarter : MonoBehaviour
{
    public GameObject elevator_ceiling;

    // Start is called before the first frame update
    void Update()
    {
        elevator_ceiling.GetComponent<Animator>().Play("New Animation");
    }
}
