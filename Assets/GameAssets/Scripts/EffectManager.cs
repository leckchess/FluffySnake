using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {
    public Camera Cam;
    public float startFieldOfView;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
        if (Cam.fieldOfView < startFieldOfView + 1 || Cam.fieldOfView > startFieldOfView - 1)
        {
            Cam.fieldOfView = Mathf.Lerp(Cam.fieldOfView, startFieldOfView, Time.deltaTime);
        }
    }
}
