﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AriseControll : MonoBehaviour {

    public Animator anim;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Arise", true);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
