﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoMovement : MonoBehaviour {

    public GameObject Actor;
    public float speed = 4;
    private Vector3 pos;
    public Material mat;
    public AudioSource StartAudio;//Add an AudioSorce to add music
    private int loopCount = 0;
    public bool onGround = true;
    public float disFromGround = 0.6f;
    public bool isAlive = true;
    private bool beginOrNot;
    public bool canuse = true; //游戏成功后进入最终的场景时不再响应用户的操作
    

    // Use this for initialization
    void Start()
    {
        StartAudio.Play();//游戏开始时播放音乐
        //Actor = GameObject.Find("Cube");
        Actor.transform.eulerAngles = new Vector3(0, 0, 0);//设置开始时候的角度（解决之前开始第一次转动幅度非90度的问题）
        //canuse = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (beginOrNot == false)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                GameObject Actor2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                StartAudio.Play();//游戏开始时播放音乐
                beginOrNot = true;
            }
        }
        if (isAlive && beginOrNot)
        {
            onGround = IsGrounded();
            pos = Actor.transform.position; //实现路径记录
            Actor.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (onGround)
            {
                GameObject Actor2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Actor2.transform.position = pos;  //实现路径记录
                Actor2.GetComponent<MeshRenderer>().material = mat;
                Actor2.GetComponent<BoxCollider>().isTrigger = true;

                if (canuse == true)
                {
                    if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))  //实现鼠标或键盘空格键点击转向
                    {
                        if (loopCount % 2 != 0)
                        {
                            Actor.transform.eulerAngles = new Vector3(0, -90, 0);
                            loopCount++;
                        }
                        else
                        {
                            Actor.transform.eulerAngles = new Vector3(0, 0, 0);
                            loopCount++;
                        }
                    }
                }
            }
        }

    }

    //判断是否在陆地上，不在陆地上无跟踪
    public bool IsGrounded()
    {
        return Physics.Raycast(Actor.transform.position, Vector3.down, disFromGround);
    }

    //判断是否撞到其他障碍物
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            StartAudio.Stop();//当发生碰撞时结束音乐
            isAlive = false;
            GameObject prime1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject prime2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject prime3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            prime1.transform.position = pos;
            prime2.transform.position = pos;
            prime3.transform.position = pos;

            prime1.AddComponent<Rigidbody>().velocity = Random.onUnitSphere * 50;
            prime2.AddComponent<Rigidbody>().velocity = Random.onUnitSphere * 50;
            prime3.AddComponent<Rigidbody>().velocity = Random.onUnitSphere * 100;

            prime1.GetComponent<MeshRenderer>().material = mat;
            prime2.GetComponent<MeshRenderer>().material = mat;
            prime3.GetComponent<MeshRenderer>().material = mat;

        }
    }

    //当与钻石接触的时候会吃钻石
    void OnTriggerEnter(Collider other)
    {
        print("接触");
        Debug.Log("Name is " + other.gameObject.name);
        if (other.gameObject.tag == "Diamond")
            other.gameObject.SetActive(false);//当接触时隐藏钻石
    }

}
