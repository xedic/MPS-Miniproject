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

    void Start()
    {
        forceBar.fillAmount = 0;
        forcePerc.text = "0";
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if(force <= maxForce) {
                force += 100;
                forceFactor++;
            }

            forceBar.fillAmount = force / (maxForce / 100) / 100;
            forcePerc.text = (Mathf.RoundToInt(forceBar.fillAmount * 100)).ToString();
        }
        else if (Input.GetKey(KeyCode.E))
        {
            if (force >= 0)
            {
                force -= 100;
                forceFactor--;
            }

            forceBar.fillAmount = force / (maxForce / 100) / 100;
            forcePerc.text = (Mathf.RoundToInt(forceBar.fillAmount * 100)).ToString();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * Mathf.Clamp(force, 0, maxForce), forcePoint.transform.position);
        }
    }
}
