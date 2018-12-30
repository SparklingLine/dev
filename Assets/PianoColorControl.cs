using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoColorControl : MonoBehaviour {
    
    public Color colorNow;
    public GameObject cube;
    public Animator anim;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            //material.color = colorNow;
            anim.SetBool("Play", true);
            cube.GetComponent<MeshRenderer>().material.color = colorNow;
            
        }
    }
}
