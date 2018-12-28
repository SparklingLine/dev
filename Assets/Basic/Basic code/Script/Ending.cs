using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ending : MonoBehaviour {

	public PianoMovement MainLine;
    public float Rate = 1;
	public float OpenNeedTime = 1;
	public float WinWaitTime = 1;
	private Transform Ending_Left;
	private Transform Ending_Right;

    public CameraComponent MainCamera;

	// Use this for initialization
	public void Start () {
		Ending_Left = this.transform.Find ("Ending_Left").GetComponent<Transform> ();
		Ending_Right = this.transform.Find("Ending_Right").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void open()
    {
		MainLine.canuse = false;
		Ending_Left.DOLocalMoveZ (-0.1f * Rate, OpenNeedTime, false);
		Ending_Right.DOLocalMoveZ (0.1f * Rate, OpenNeedTime, false);
        //if (MainLine.Camera.GetComponent<MainCarmera>() != null)
        //{
        //    Debug.Log("main camera");
        //    MainLine.Camera.GetComponent<MainCarmera>().enabled = false;
        //}
        MainCamera.follow = false;
        //Invoke ("win", WinWaitTime);  自己定义的player还没有GameOver函数，无法调用
    }

	public void win(){
		//MainLine.GameOver (true, true);
	}
}
