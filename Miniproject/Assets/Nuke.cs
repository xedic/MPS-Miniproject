using UnityEngine;
using System.Collections;

public class Nuke : MonoBehaviour
{
    public float radius = 30.0F;
    public float power = 20F;
    public GameObject explosionParticle;
    public GameObject dust;
    public GameObject flare;


    void Start()
    {
    }

    void OnCollisionEnter(Collision c)
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        if (c.gameObject.tag != "Player")
        {
            CameraShake.ShakeViolently();
            foreach (Collider hit in colliders)
            {
                if (hit && hit.GetComponent<Rigidbody>())
                    hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3F);

            }
            GameObject t = Instantiate(explosionParticle);
            t.transform.position = gameObject.transform.position;
            Destroy(gameObject);
            GameObject d = Instantiate(dust);
            d.transform.position = GameObject.Find("catapult").transform.position;
            d.SetActive(true);
            GameObject f = Instantiate(flare);
            f.transform.position = explosionPos;
            f.SetActive(true);

            Time.timeScale = .1f;
        }
    }

}
