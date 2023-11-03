using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControler : MonoBehaviour
{
    public Rigidbody theRB;

    public float forwardAccel = 8f, reverseAccel = 4f, maxSpeed = 50f, turnStrength = 180;

    public float speedInput { get; private set; }
    public float turnInput { get; private set; }

    public void ResetCar()
    {
        transform.position = new Vector3(102, 5, 93);
        transform.eulerAngles = new Vector3(0, -51, 0);
    }

    // Start is called before the first frame update
    public void Start()
    {
        theRB.transform.parent = null;
    }

    // Update is called once per frame
    public void Update()
    {
        speedInput = 0f;

        //SetSpeedInput (Input.GetAxisRaw("Vertical"));
        //SetTurnInput(Input.GetAxisRaw("Horizontal"));
        //turnInput = Input.GetAxis("Horizontal");

        //transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));


        transform.position = theRB.transform.position;
    }

    public void SetTurnInput(float input_H)
    {
        float newRotation = input_H * turnStrength * Time.deltaTime /* * , Input.GetAxisRaw("Vertical")*/;
        //transform.Rotate(0, newRotation, 0, Space.World);
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, newRotation, 0f));

    }
    public void SetSpeedInput(float input)
    {
        if (input > 0)
        {
            speedInput = input * forwardAccel * 1000f;
        }
        if (input < 0)
        {
            speedInput = input * reverseAccel * 1000f;
        }
    }

    private void FixedUpdate()
    {
        if(Mathf.Abs(speedInput) > 0)
        {
            theRB.AddForce(transform.forward* speedInput);
        }
    }
}
