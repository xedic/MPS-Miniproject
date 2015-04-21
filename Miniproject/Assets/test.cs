using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    public GameObject pivot;
	// Use this for initialization
	void Start () {
	
	}

    float rotation = 0.5f;
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            rotation += 100f;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && transform.rotation.z <= 90f)
        {
            //StartCoroutine("Fire");
            //transform.Rotate(Vector3.forward, rotation);
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up*1000, pivot.transform.position);
            //rotation = 0;
        }
        //else if(transform.rotation.z > 0)
        //{
        //    transform.Rotate(Vector3.forward, -0.5f);
        //}
	}

    IEnumerator Fire()
    {
        float time = rotation / 90f;

        while (transform.rotation.eulerAngles.z < 90f)
        {
            transform.Rotate(Vector3.forward, time);
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }
}
