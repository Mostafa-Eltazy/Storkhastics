using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour {

    public float movespeed;
    public float jumpheight;
    public Rigidbody body;
    ///////////////////////
    private bool grounded;
    public Collider groundcheck;
    //////////////////////
    public float smooth;
    private Quaternion targetrotation;
	// Use this for initialization
	void Start () {
		
        body=GetComponent<Rigidbody>();
        groundcheck = GetComponent<Collider>();
        targetrotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

        //to chech if grounded
        grounded = Physics.Raycast(transform.position, Vector3.down, groundcheck.bounds.extents.y + 0.1f);
        //to move forward
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            float vertical =  movespeed * Time.deltaTime;
            transform.Translate(0, 0, vertical);
        }
        /////////////  Auto set up ///////////////////
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetrotation *= Quaternion.AngleAxis(45, Vector3.down);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetrotation *= Quaternion.AngleAxis(45, Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && grounded)
        {
            targetrotation *= Quaternion.AngleAxis(90, Vector3.down);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetrotation, 10 * smooth * Time.deltaTime); 
    //////////To rotate around it's own axis //
    //////////   Manual setup  ///////////////
    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        transform.Rotate(0,-45.0f, 0);
    //    }
    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //         transform.Rotate(0,45.0f, 0);
    //     }
    //     if (Input.GetKeyDown(KeyCode.DownArrow))
    //     {
    //         transform.Rotate(0,180.0f, 0);
    //     }
	}
}
