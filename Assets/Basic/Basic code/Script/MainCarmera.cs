﻿using System.Collections; using System.Collections.Generic; using UnityEngine;  public class MainCarmera : MonoBehaviour {      public MainLine mainObject;     public float smoothTime = 0.5f;   	private Vector3 cameraVelocity = Vector3.zero; 	public Vector3 Vector = Vector3.zero;    	public Vector3 Rotation = Vector3.zero;  	public bool LookAt;     void Start ()
    { 		mainObject.Camera = this.gameObject; 		transform.Rotate (Rotation);     } 	void Update ()
    { 		this.transform.position = Vector3.SmoothDamp(transform.position, mainObject.gameObject.transform.position + Vector, ref cameraVelocity, smoothTime); 		if (LookAt == true) { 			this.transform.LookAt (mainObject.transform.position); 		}     } } 