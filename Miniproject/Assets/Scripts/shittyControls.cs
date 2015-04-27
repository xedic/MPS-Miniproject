using UnityEngine;
using System.Collections;

public class shittyControls : MonoBehaviour {

    float turnspeed = 2f;
    float speed = 10f;
    public GameObject moveBar;
    float movebarMaxY = 1.86f;
    float movebarMinY = 0.15f;


	// Update is called once per frame
	void Update () {
        float turn = Input.GetAxis("Horizontal");
        float forwardSpeed = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up, turn*turnspeed);
        transform.position += -transform.forward * (forwardSpeed * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.L) && moveBar.transform.localPosition.y >= movebarMinY)
            moveBar.transform.position -= new Vector3(0f, .01f, 0f);
        else if (Input.GetKey(KeyCode.O) && moveBar.transform.localPosition.y <= movebarMaxY)
            moveBar.transform.position += new Vector3(0f, .01f, 0f);
	}
}
