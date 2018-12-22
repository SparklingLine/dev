using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour {
    public GameObject Cube;
    public Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - Cube.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = Cube.transform.position + offset;
	}
}
