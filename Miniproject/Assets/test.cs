using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    public GameObject pivot;
	// Use this for initialization
	void Start () {
	
	}

    float force = 0.5f;
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            force += 100f;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && transform.rotation.z <= 90f)
        {
            Debug.Log("testsefshu: " + force);
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * force, pivot.transform.position);
            force = 0;
        }
        //else if(transform.rotation.z > 0)
        //{
        //    transform.Rotate(Vector3.forward, -0.5f);
        //}
	}
}
