using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoController : MonoBehaviour {

    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;
    public Animator anim5;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            anim1.SetBool("Arise", true);
            anim2.SetBool("Arise", true);
            anim3.SetBool("Arise", true);
            anim4.SetBool("Arise", true);
            anim5.SetBool("Arise", true);

        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
