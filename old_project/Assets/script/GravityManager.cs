using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{

	public static Vector3 nowgravity;
	public static Vector3 oldgravity;
	public static bool playeranglechange = true;
	bool stay = true;

    // Start is called before the first frame update
    void Start()
    {
	Physics.gravity = new Vector3(0,-98.1f,0);
	nowgravity = Physics.gravity;
	oldgravity = nowgravity;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.G) && stay)
        {
            nowgravity = -1.0f * nowgravity;
	    stay = false;
	    Invoke("staytrue",0.5f);
        }

	if((Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && stay)
	{
		stay = false;
	    	Invoke("staytrue",1.0f);
        	if(Input.GetKey(KeyCode.W))
        	{
			nowgravity = max(new Vector3(PlayerController.forward.x,0,0),new Vector3(0,PlayerController.forward.y,0),new Vector3(0,0,PlayerController.forward.z)).normalized * 98.1f;
        	}
		else if(Input.GetKey(KeyCode.S))
        	{
			nowgravity = max(new Vector3(PlayerController.back.x,0,0),new Vector3(0,PlayerController.back.y,0),new Vector3(0,0,PlayerController.back.z)).normalized * 98.1f;
        	}
		else if(Input.GetKey(KeyCode.D))
        	{
			nowgravity = max(new Vector3(PlayerController.right.x,0,0),new Vector3(0,PlayerController.right.y,0),new Vector3(0,0,PlayerController.right.z)).normalized * 98.1f;
        	}
		else if(Input.GetKey(KeyCode.A))
        	{
			nowgravity = max(new Vector3(PlayerController.left.x,0,0),new Vector3(0,PlayerController.left.y,0),new Vector3(0,0,PlayerController.left.z)).normalized * 98.1f;
        	}
	}

	if(oldgravity != nowgravity)
	{

	        Physics.gravity = nowgravity;
		playeranglechange = true;
		BackMoveCube.localGravity = -1.0f * nowgravity;
		//oldの更新はPlayerControllerでやってる

	}

    }
    public void staytrue()
    {

	stay = true;

    }
    public Vector3 max(Vector3 a,Vector3 b,Vector3 c)
    {

	Vector3 max = a;
	if(max.sqrMagnitude < b.sqrMagnitude)
	{
		max = b;
	}
	if(max.sqrMagnitude < c.sqrMagnitude)
	{
		max = c;
	}
	return max;
   }
}
