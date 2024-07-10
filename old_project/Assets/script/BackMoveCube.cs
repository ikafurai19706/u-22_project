using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMoveCube : MonoBehaviour
{

	public static Vector3 localGravity;
	private Rigidbody rBody;

    // Start is called before the first frame update
    void Start()
    {
        
        rBody = this.GetComponent<Rigidbody>();
        rBody.useGravity = false;
	    localGravity = Physics.gravity * -1.0f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void FixedUpdate () 
    {
        SetLocalGravity (); //重力をAddForceでかけるメソッドを呼ぶ。
    }

    private void SetLocalGravity()
    {
        rBody.AddForce (localGravity, ForceMode.Acceleration);
    }
}
