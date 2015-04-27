using UnityEngine;
using System.Collections;

public class NukeFlare : MonoBehaviour {

    float maxy = 100F;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if(transform.position.y >= maxy)
            transform.position += new Vector3(0, 0.1F, 0);

        if(Time.timeScale <= 0.3f)
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1, 0.001f);
        else
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1, 0.01f);

        Debug.Log(Time.timeScale);
	}
}
