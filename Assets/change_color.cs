using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_color : MonoBehaviour {
    public Material material;
    public Color colorNow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            material.color = colorNow;
        }
    }
}
