using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatedObjects : MonoBehaviour {

    public Animator anim;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("down", true);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
