using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator_goDown : MonoBehaviour
{
    public GameObject elevatorCeiling;
    public GameObject elevatorGround;

    private void OnTriggerStay()
    {
        elevatorGround.transform.position -= elevatorGround.transform.forward * Time.deltaTime;
        elevatorCeiling.transform.position -= elevatorCeiling.transform.forward * Time.deltaTime;
    }
}
