using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromSkyController : MonoBehaviour {

    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            anim.SetBool("Fall", true);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

