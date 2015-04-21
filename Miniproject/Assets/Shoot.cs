using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject forcePoint;

    float force = 0f;
    float maxForce = 5000f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            force += 100f;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Force: " + Mathf.Clamp(force, 0, maxForce));
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * Mathf.Clamp(force, 0, maxForce), forcePoint.transform.position);
            force = 0;
        }
    }
}
