using UnityEngine;
using System.Collections;
public class CameraShake : MonoBehaviour {
    private static CameraShake _instance = null;
    static private CameraShake GetInstance(){
        if(_instance == null){
            _instance = GameObject.Find("MainCamera").gameObject.AddComponent<CameraShake>();
        }
        return _instance;
    }

    static public void Shake(){
        CameraShake cs = GetInstance();
        cs.StartCoroutine(cs._Shake(0.25f, 0.008f));
    }

    static public void ShakeViolently()
    {
        CameraShake cs = GetInstance();
        cs.StartCoroutine(cs._Shake(.5f, 1f));
    }

    private IEnumerator _Shake(float magnitude, float duration){
        GameObject cam = (GameObject)GameObject.Find("MainCamera");
        while(magnitude > 0){
            Vector3 pos = cam.transform.position;
            cam.transform.position = pos + Random.insideUnitSphere * magnitude;
            magnitude -= duration;
            yield return new WaitForFixedUpdate();
        }
    }
}
