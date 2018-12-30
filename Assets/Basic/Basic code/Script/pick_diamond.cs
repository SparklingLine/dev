using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_diamond : MonoBehaviour{

	public CubeMovement MainLine;  //edited
    public GameObject remains;
	public GameObject PickDiamondEffect;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Diamond: " + MainLine.diamondCount);
		if (other.GetComponent<CubeMovement> () != null) {
			MainLine.diamondCount++;  //edited
            Debug.Log(MainLine.diamondCount);
            Instantiate (remains, this.transform.position, this.transform.rotation);
			Destroy (Instantiate(PickDiamondEffect, this.transform.position, Quaternion.Euler(Vector3.zero)), 30f);
			Destroy (this.gameObject);          
		}
    }
}
