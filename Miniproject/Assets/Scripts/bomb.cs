using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {

    private AudioSource _audioSource;
    public float radius = 10.0F;
    public float power = 0.1F;
    public GameObject explosionParticle;

    void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision c)
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        if (c.gameObject.tag != "Player")
        {
            CameraShake.Shake();
            _audioSource.Play();
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
