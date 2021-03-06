﻿using UnityEngine;
using System.Collections;

public class SpawnProjectile : MonoBehaviour {	
	// Update is called once per frame

    public GameObject bomb;
    public GameObject nuke;

	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            temp.transform.position = gameObject.transform.position;
            temp.AddComponent<Rigidbody>();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject temp = Instantiate(bomb);
            temp.transform.position = gameObject.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject temp = Instantiate(nuke);
            temp.transform.position = gameObject.transform.position;
        }
	}
}
