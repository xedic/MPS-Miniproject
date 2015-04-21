using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject forcePoint;

    float force = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            force += 100f;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("testsefshu: " + force);
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * force, forcePoint.transform.position);
            force = 0;
        }
    }
}
