using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class CubeMovement : MonoBehaviour {

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
    public int diamondCount=0;
    public Text countText;
    public int deadHeight;

    private int now;
    public bool canuse = true; //游戏成功后进入最终的场景时不再响应用户的操作

    public Color originColor;

    private float timeLeft = 1.0f;
    [HideInInspector]public bool colorChange;
    [HideInInspector]public Color targetColor;



    //public GameObject dieEffect;
    //public AudioClip dieSound;
    //public bool stop;

    // Use this for initialization
    void Start () {
        StartAudio.Play();//游戏开始时播放音乐
        //Actor = GameObject.Find("Cube");
        Actor.transform.eulerAngles = new Vector3(0, 0, 0);//设置开始时候的角度（解决之前开始第一次转动幅度非90度的问题）
        
        countText.text = "Diamond Number: " + diamondCount;
        //countText.alignment = TextAnchor.UpperLeft;  企图把Text放在左上角，但是实验不成功
        if (Actor.gameObject.tag == "Player1")
        {
            now = 2;
        }
        else now = 1;

        this.GetComponent<MeshRenderer>().material.color = originColor;
        mat.color = originColor;

    }
	
	// Update is called once per frame
	void Update () {
        countText.text = "Diamond Number: " + diamondCount;
        if (beginOrNot == false)
        {
            if (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space))
            {
                GameObject Actor2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                StartAudio.Play();//游戏开始时播放音乐
                beginOrNot = true;
            }
        }
        //当player下落到非指定路径后游戏结束
        if (Actor.transform.position.y < deadHeight)  //低于沙漠的高度（游戏设计竭泽而渔，海水下面为沙漠，有一层沙漠景象，所以改为比沙漠高度还低）
        {
            StartAudio.Stop();//当发生碰撞时结束音乐
            isAlive = false;
            Time.timeScale = 0;
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

                if (canuse == true)  //当到到终点后，cube不会再随着用户的操作转向
                {
                    if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))  //实现鼠标或键盘空格键点击转向
                    {                        
                        if (loopCount % 2 != 0)
                        {
                            if (now == 1)
                            {
                                Actor.transform.eulerAngles = new Vector3(0, 90, 0);
                                //Actor.transform.rotation = new Vector3(0, 90, 0);
                            }
                            else
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
        if (colorChange)
        {
            ColorChange();
        }

	}

    //判断是否在陆地上，不再陆地上无跟踪
    public bool IsGrounded()
    {
        return Physics.Raycast(Actor.transform.position, Vector3.down, disFromGround);
    }

    //判断是否撞到其他障碍物
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter function");
       // Debug.Log(speed);
        Debug.Log(onGround);
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("Obstacle");
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

            //GameOver();
            //岩GameOverControl
           // GameOverControl gameover= new GameOverControl();
           // gameover.GameOver(false,2, diamondCount, 0);
            //GameOver(0, 0, diamondCount, 0);

        }
        else if (collision.gameObject.tag == "diamond")
        {
            Debug.Log("Collision on diamond");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        onGround = IsGrounded();
    }

    //public void GameOver()
    //{
    //    //dieEffect.GetComponent<MeshRenderer>().material = this.GetComponent<MeshRenderer>().material;
    //    Destroy(Instantiate(dieEffect, this.transform.position, this.transform.rotation), 10f);
    //    StartAudio.Stop();
    //    isAlive = false;
    //    AudioSource.PlayClipAtPoint(dieSound, this.transform.position);
    //    this.GetComponent<Rigidbody>().isKinematic = true;
    //    stop = true;
    //}



    //当与钻石接触的时候会吃钻石
    void OnTriggerEnter(Collider other)
    {
        print("接触");
        Debug.Log("Name is " + other.gameObject.name);
        if (other.gameObject.tag == "Diamond")
        {
            diamondCount++;
            other.gameObject.SetActive(false);//当接触时隐藏钻石
        }
    }


    public void ColorChange()
    {
        if (timeLeft <= Time.deltaTime)
        {
            // transition complete
            // assign the target color
            this.GetComponent<MeshRenderer>().material.color = targetColor;
            mat.color = targetColor;

            // start a new transition
            //targetColor = new Color(Random.value, Random.value, Random.value);
            timeLeft = 1.0f;
            colorChange = false;
        }
        else
        {
            // transition in progress
            // calculate interpolated color
            this.GetComponent<MeshRenderer>().material.color = Color.Lerp(this.GetComponent<MeshRenderer>().material.color, targetColor, Time.deltaTime / timeLeft);
            mat.color = Color.Lerp(mat.color, targetColor, Time.deltaTime / timeLeft);
            // update the timer
            timeLeft -= Time.deltaTime;
        }
    }

}
