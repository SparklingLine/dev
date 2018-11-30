using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour {
    public GameObject Cube;
    public Vector3 offsite;
	// Use this for initialization
	void Start () {
        offsite = transform.position - Cube.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = Cube.transform.position + offsite;
	}
}
