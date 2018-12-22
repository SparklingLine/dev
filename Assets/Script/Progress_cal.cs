using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress_cal : MonoBehaviour {

    public AudioSource music;
    private float length;
    private float currentTime;
    public Animator anim;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        length = music.clip.length;
        currentTime = music.time;
        if(currentTime > 2.16f)
        {
            anim.SetBool("Play", true);
        }
	}
}
