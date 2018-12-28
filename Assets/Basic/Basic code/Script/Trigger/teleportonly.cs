using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportonly : MonoBehaviour {

	public Vector3 To_Teleport_position = Vector3.zero;
	public GameObject WantToTeleportObject;

	public void OnTriggerEnter (Collider other)
	{
		WantToTeleportObject.transform.position = new Vector3 (To_Teleport_position.x, To_Teleport_position.y, To_Teleport_position.z);
	}
}
