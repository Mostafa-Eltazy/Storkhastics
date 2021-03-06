﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFlying : MonoBehaviour
{

    private bool grounded;
    public Collider groundcheck;
    public Rigidbody body;
    ////////////////////////////
    public float alttitude;
    public float glide;
    public float gravity;
    public float brake;
    
    /////////////////////////////
    public bool preparetoboost;
    private float boostingwindow;
    public float timeforboosting;
    public float boostingforce;
    /////////////////////////////////
    // Use this for initialization
    void Start()
    {
       
        preparetoboost = false;
        boostingwindow = timeforboosting;
    }

    // Update is called once per frame
    void Update()
    {
        if (preparetoboost)
        {
            boostingwindow -= Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space) && !grounded)
                {
                  if (boostingwindow > 0.0f)
                   {
                       Debug.Log("fffffffffffffffffffffffffffffffff");
                     body.AddForce(transform.forward * (boostingforce), ForceMode.Force);
                   }
                }
            if (boostingwindow < 0.0f) {
                preparetoboost = false;
            }
        }
            Physics.gravity = new Vector3(0, gravity, 0);
            grounded = Physics.Raycast(transform.position, Vector3.down, groundcheck.bounds.extents.y + 0.1f);
            if (Input.GetKey(KeyCode.Space) && !grounded)
            {

                float vertical = Input.GetAxis("Vertical") * (alttitude + 1) * Time.deltaTime;
                transform.Translate(0, 0, vertical);

            }
            if (Input.GetKeyUp(KeyCode.Space) && !grounded)
            {
                Debug.Log("jidsjfs");
                boostingwindow = timeforboosting;
                preparetoboost = true;
            } 
           
            if (Input.GetKey(KeyCode.UpArrow))
            {
                body.velocity = new Vector3(body.velocity.x, alttitude, body.velocity.z);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                body.velocity = new Vector3(body.velocity.x, -glide, body.velocity.z);
            }
           
            if (Input.GetKey(KeyCode.C) && !grounded)
            {
               
               body.AddForce(-(transform.forward * (brake)), ForceMode.Force);
            }
        }
    }

