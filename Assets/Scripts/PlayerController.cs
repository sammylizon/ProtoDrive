using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Search;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;
    public float horsePower;
    private float horizontalInput;
    private float forwardInput;
    public float turnSpeed;

    [SerializeField] GameObject centreM; 

    private Rigidbody rb;
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centreM.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if(IsOnGround())
        {
            //Input Management
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Vehicle Acceleration
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        rb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);

        //Vehicle Rotation  
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        //speed in mps
        speed = Mathf.RoundToInt(rb.velocity.magnitude * 3.6f); //For kph, multiply by 3.6

        speedText.text = $"{speed} km/h";

        rpm = speed % 30 * 40; 
        rpmText.SetText($"RPM : {rpm}");
        }
        
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if(wheel.isGrounded)
            {
                wheelsOnGround++;
            }
            
        }

        if(wheelsOnGround ==4 )
        {
            return true;
        } 
        else
        {
            return false;
        }
    }
}

// Completed the Challenge but can add Bonus challenges : https://learn.unity.com/tutorial/bonus-features-1-share-your-work#
// Add more obsatcles, vehicles moving towards, camera switch FPS and Local Multiplayer 
