using UnityEngine;
using System.Collections;

public class SpawnProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            temp.transform.position = gameObject.transform.position;
            temp.AddComponent<Rigidbody>();
        }
	}
}
