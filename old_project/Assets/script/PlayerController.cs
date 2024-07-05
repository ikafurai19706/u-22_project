using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    float speed = 3.0f;
    GameObject Camera;
    Vector3 hako;
    Vector3 idou;
    Vector3 force;
    Vector3 jiku;
    bool hanntenn = false;
    int hanntennCount = 0;
    bool kaitenn = false;
    int kaitennCount = 0;

 　public static Vector3 forward;
 　public static Vector3 back;
 　public static Vector3 right;
 　public static Vector3 left;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
	idou = new Vector3(0,0,1);
    }
 
    void FixedUpdate()
    {

	Camera = gameObject.transform.GetChild(0).gameObject;

	if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.A))
	{
        	if (Input.GetKey(KeyCode.W))
        	{
            	hako = Camera.transform.rotation * Vector3.forward;
	    	forward = new Vector3(hako.x*idou.x*100,hako.y*idou.y*100,hako.z*idou.z*100).normalized * speed;
	    	force += forward;
        	}
        	if (Input.GetKey(KeyCode.S))
        	{
            	hako = Camera.transform.rotation * Vector3.forward ;
	    	back = new Vector3(hako.x*idou.x*100,hako.y*idou.y*100,hako.z*idou.z*100).normalized* speed * -1.0f;
	    	force += back;
        	}
        	if (Input.GetKey(KeyCode.D))
        	{
            	right = Camera.transform.rotation * Vector3.right * speed;
            	force += right;
        	}
        	if (Input.GetKey(KeyCode.A))
        	{
            	left = Camera.transform.rotation * Vector3.right * speed * -1.0f;
            	force += left;
        	}
		rb.velocity = force;
		force = new Vector3(0,0,0);
	}
	else
	{
	    rb.velocity = new Vector3(0,0,0);
	}

	if(hanntenn && hanntennCount < 30)
	{
		transform.RotateAround(transform.position,idou,6f);
		hanntennCount++;
	}
	else if(hanntennCount == 30)
	{
		hanntennCount = 0;
		hanntenn = false;
	}
	if(kaitenn && kaitennCount < 30)
	{
		transform.RotateAround(transform.position,jiku,-3.0f);
		kaitennCount++;
	}
	else if(kaitennCount == 30)
	{
		kaitennCount = 0;
		kaitenn = false;
	}

	if(GravityManager.playeranglechange == true)
	{

		GravityManager.playeranglechange = false;

		if(GravityManager.nowgravity.x != 0)
		{
			idou.x = 0.0f;
		}
		else
		{
			idou.x = 1.0f;
		}
		if(GravityManager.nowgravity.y != 0)
		{
			idou.y = 0.0f;
		}
		else
		{
			idou.y = 1.0f;
		}
		if(GravityManager.nowgravity.z != 0)
		{
			idou.z = 0.0f;
		}
		else
		{
			idou.z = 1.0f;
		}

		if(Vector3.Cross(GravityManager.nowgravity,GravityManager.oldgravity) == new Vector3(0,0,0))
		{
			hanntenn = true;
		}
		else
		{
			kaitenn = true;
			jiku = Vector3.Cross(GravityManager.nowgravity,GravityManager.oldgravity);
		}
		GravityManager.oldgravity = GravityManager.nowgravity;

	}
        
    }
}
