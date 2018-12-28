using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour {
    public GameObject Cube;
    public Vector3 offset;
    public bool follow;

	// Use this for initialization
	void Start () {
        offset = transform.position - Cube.transform.position;
        follow = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (follow == true)
        {
            transform.position = Cube.transform.position + offset;
        }
	}
}
