using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoKeyPlay : MonoBehaviour {

    public Animator anim1;
    public Animator anim2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            anim1.SetBool("Play", true);
            anim2.SetBool("Play", true);
        }
    }
}
