using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTrigger : MonoBehaviour {

	public Vector3 Gravity = new Vector3(0f, -5f, 0f);

	public void OnTriggerEnter (Collider other) {
		Physics.gravity = Gravity;
	}
}
