using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roatationtest : MonoBehaviour {


    public float rotatespeed;
    private Transform targtotation;
    public GameObject rotator;
   public Quaternion newRotation;
    void Start()
    {


        newRotation = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {

            transform.Rotate(-Vector3.up * rotatespeed*Time.deltaTime);
        
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.Rotate(Vector3.up * rotatespeed);
        }

        
    }


}

