using UnityEngine;
using System.Collections;

public class WheelControls : MonoBehaviour {

    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelBR;
    public WheelCollider WheelBL;
    
    public float wheelTorque;
    public float steerAngle;
    public float brakeForce;

    public Transform moveBar;
    float movebarMaxY = 1.86f;
    float movebarMinY = 0.15f;

	// Update is called once per frame
	void Update () {
        float torque = Input.GetAxis("Vertical") * wheelTorque;
        float angle = Input.GetAxis("Horizontal") * steerAngle;

        WheelBL.motorTorque = -torque;
        WheelBR.motorTorque = -torque;

        WheelFL.steerAngle = angle;
        WheelFR.steerAngle = angle;



        if (Input.GetKeyDown(KeyCode.X))
        {
            WheelBR.brakeTorque = brakeForce;
            WheelBL.brakeTorque = brakeForce;
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            WheelBR.brakeTorque = 0;
            WheelBL.brakeTorque = 0;
        }


        if (Input.GetKey(KeyCode.L) && moveBar.localPosition.y >= movebarMinY)
            moveBar.position -= new Vector3(0f, .1f, -0.1f);
        else if (Input.GetKey(KeyCode.O) && moveBar.localPosition.y <= movebarMaxY)
            moveBar.position += new Vector3(0f, .1f, -0.1f);
	}
}
