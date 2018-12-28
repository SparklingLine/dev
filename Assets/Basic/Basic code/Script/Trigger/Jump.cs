using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Jump : MonoBehaviour {

	public Vector3 AddValue = Vector3.zero;
	public float JumpPower;
	public float NeedTime = 1;
	public bool only = false;
	public GameObject JumpObject;

	void OnCollisionEnter (Collision collision){
		StartJump (collision.collider);
	}

	void OnTriggerEnter (Collider Other) {
		StartJump (Other);
	}

	public void StartJump(Collider Other){
		if (Other.tag == "line"){
			if (only != true) {
				Other.GetComponent<Transform> ().DOJump (Other.transform.position + AddValue, JumpPower, 1, NeedTime, false);
			} else {
				JumpObject.GetComponent<Transform> ().DOJump (JumpObject.transform.position + AddValue, JumpPower, 1, NeedTime, false);
			}
		}
	}
}
