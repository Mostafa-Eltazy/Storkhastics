using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    private bool grounded;
    public Collider groundcheck;
    public Rigidbody body;
    public float groundedhoveralttitude;
    public float airbornhoveralttitude;
    public float WingForce;
    public float alttitude;
    public int boostcounter;
    public float wingrestinterval = 2f;
    public bool rest;
    public bool boost;
    public float normalgravityeffect;
    public float lightgravityeffect;
    
    // Use this for initialization
    void Start()
    {

        Physics.gravity = new Vector3(0, normalgravityeffect, 0);
        rest = false;
        boost = true;
        body = FindObjectOfType<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        grounded = Physics.Raycast(transform.position, Vector3.down, groundcheck.bounds.extents.y + 0.1f);
        if(rest){

            
            wingrestinterval-=Time.deltaTime;
            if(wingrestinterval<0.0f){
                boostcounter=0;
                boost=true;
                rest=false;
            }
        }
        //To hover from ground
        if (Input.GetButton("Jump") && grounded)
        {
            Debug.Log("ground hover");
            body.AddForce(transform.up * groundedhoveralttitude);
        }
        //To hover while airborn
        if (Input.GetButton("Jump"))
        {
            Debug.Log("air hover");
            body.AddForce(transform.up * airbornhoveralttitude);
        }
        //To eject his body forward
        if (Input.GetButtonUp("Jump") && !grounded)
        {
            
            Debug.Log("Fly");
            boostcounter += 1;
            Physics.gravity = new Vector3(0, lightgravityeffect, 0);
            body.AddForce(transform.up * (alttitude * 0.1f), ForceMode.Force);
         
            if(boost)
            {  
                
                if(boostcounter<2)
                {
                  body.AddForce(transform.up * alttitude, ForceMode.Force);
                  body.AddForce(transform.forward * WingForce, ForceMode.Force);
                  
                }
                else
                {
                 wingrestinterval=2.0f;
                 rest=true;
                 boost=false;
                }
            }             
         }
          //  transform.Translate(0, 0, 3.0f);
            
        }
 
    }

