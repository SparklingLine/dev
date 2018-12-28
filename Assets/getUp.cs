using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getUp : MonoBehaviour {
    public Animator anim1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim1.SetBool("getUp", true);
        }
    }
}
