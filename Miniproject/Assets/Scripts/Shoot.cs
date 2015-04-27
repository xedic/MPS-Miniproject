using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

    public GameObject forcePoint;
    public Image forceBar;
    public Text forcePerc;

    float force = 0f;
    float maxForce = 10000;
    float forceFactor = 1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if(force <= maxForce) {
                force += 50 * forceFactor;
                forceFactor++;
            }
                
            forceBar.fillAmount = force / (maxForce / 100) / 100;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            if (force >= 0)
            {
                force -= 50 * forceFactor;
                forceFactor--;
            }

            forceBar.fillAmount = force / (maxForce / 100) / 100;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Force: " + Mathf.Clamp(force, 0, maxForce));
            forcePerc.text = (Mathf.RoundToInt(forceBar.fillAmount * 100)).ToString();
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * Mathf.Clamp(force, 0, maxForce), forcePoint.transform.position);
        }
    }
}
