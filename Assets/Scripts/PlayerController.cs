using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 0f;
    public float horizontalInput;
    public float forwardInput;
    public float turnSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Input Management
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Vehicle Acceleration
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        //Vehicle Rotation  
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}

// Completed the Challenge but can add Bonus challenges : https://learn.unity.com/tutorial/bonus-features-1-share-your-work#
// Add more obsatcles, vehicles moving towards, camera switch FPS and Local Multiplayer 
