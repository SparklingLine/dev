using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour {

    public GameObject Actor;
    public float speed = 1;
    private Vector3 pos;
    public Material mat;
    private int loopCount = 1;
    public bool onGround = true;
    public float disFromGround = 0.6f;
    public bool isAlive = true;

	// Use this for initialization
	void Start () {
        //Actor = GameObject.Find("Cube");
	}
	
	// Update is called once per frame
	void Update () {
        if (isAlive)
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

                if (Input.GetMouseButtonDown(0))  //实现鼠标点击转向
                {
                    if (loopCount % 2 != 0)
                    {
                        Actor.transform.eulerAngles = new Vector3(0, 90, 0);
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

    //判断是否在陆地上，不再陆地上无跟踪
    public bool IsGrounded()
    {
        return Physics.Raycast(Actor.transform.position, Vector3.down, disFromGround);
    }

    //判断是否撞到其他障碍物
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
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

            //var name = collision.gameObject.name;

            //Debug.Log("Name is " + name);
            //GameObject.Destroy(collision.gameObject);

        }
    }

    //public void OnCollisionExit(Collision collision)
    //{
        
    //}
}
