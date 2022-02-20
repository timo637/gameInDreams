using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedScript : MonoBehaviour
{

    public Text notificationText;
    bool collidedWithBed = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (collidedWithBed)
        {
            Debug.Log("b");
            // notificationText.text = "Press 'F' to go to sleep.";
        }
        else
        {
            // notificationText.text = "";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // player.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0));
    }
}
