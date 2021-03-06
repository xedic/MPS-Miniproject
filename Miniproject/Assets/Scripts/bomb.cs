﻿using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {
    public float radius = 10.0F;
    public float power = 0.1F;
    public GameObject explosionParticle;

    void Start() {
    }

    void OnCollisionEnter(Collision c)
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        if (c.gameObject.tag != "Player")
        {
            CameraShake.Shake();
            foreach (Collider hit in colliders)
            {
                if (hit && hit.GetComponent<Rigidbody>())
                    hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3F);

            }
            GameObject t = Instantiate(explosionParticle);
            t.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }

    }

}
