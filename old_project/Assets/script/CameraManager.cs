using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] GameObject player;
    float gy,gx;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
 
        if (Mathf.Abs(mx) > 0.001f)
        {
            gy = GravityManager.nowgravity.y;
	    if(gy == 0)
	    {

		gy = 98.1f;

	    }
            transform.RotateAround(player.transform.position, GravityManager.nowgravity, mx * -1.0f);
        }
 
        // Y方向に一定量移動していれば縦回転
        if (Mathf.Abs(my) > 0.001f)
        {
            gx = GravityManager.nowgravity.x;
	    if(gx == 0)
	    {

		gx = -98.1f;

	    }
            transform.RotateAround(player.transform.position, transform.right, my * gx / 98.1f * -1.0f);
        }

    }
}
