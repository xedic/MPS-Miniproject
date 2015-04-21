using UnityEngine;
using System.Collections;

public class SpawnProjectile : MonoBehaviour {	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            temp.transform.position = gameObject.transform.position;
            temp.AddComponent<Rigidbody>();
        }
	}
}
