﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatedObjects : MonoBehaviour {

    public Animator anim;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            anim.SetBool("down", true);
        }
    }

}
