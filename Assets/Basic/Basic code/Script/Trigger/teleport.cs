using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

	public Vector3 To_Teleport_position = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter (Collider other)
	{
		other.transform.position = new Vector3 (To_Teleport_position.x, To_Teleport_position.y, To_Teleport_position.z);
	}
}
