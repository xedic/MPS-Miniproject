using UnityEngine;
using System.Collections;

public class shittyControls : MonoBehaviour {

    float turnspeed = 2f;
    float speed = 10f;

	// Update is called once per frame
	void Update () {
        float turn = Input.GetAxis("Horizontal");
        float forwardSpeed = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up, turn*turnspeed);
        transform.position += -transform.forward * (forwardSpeed * speed * Time.deltaTime);
	}
}
