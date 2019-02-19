using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour {

    public Transform path;
    public float maxsteerangle;

    public float maxtorque =80f;
    public float currentspeed;
    public float maxspeed = 100f;

    public WheelCollider wheelFL;
    public WheelCollider wheelFR;

    private List<Transform> nodes;
    private int currentNode = 0;


	// Use this for initialization
	void Start () {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++) {
            if (pathTransforms[i] != path.transform) {
                nodes.Add(pathTransforms[i]);
            }
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        MotionalongPath();
        Drive();
        checkdistancetonode();
	}

    private void checkdistancetonode()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 2f) {

            wheelFL.motorTorque = 10f;
            wheelFR.motorTorque = 10f;
            if (currentNode == nodes.Count - 1)
            {

                currentNode = 0;
            }
            else {
                currentNode++;
            }
        }
    }

    private void Drive()
    {
        currentspeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;
        if (currentspeed < maxspeed)
        {
            wheelFL.motorTorque = maxtorque;
            wheelFR.motorTorque = maxtorque;
        }
        else {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
        }
    }

    private void MotionalongPath()
    {
        Vector3 relativevector = transform.InverseTransformPoint(nodes[currentNode].position);
        print(relativevector);
        float newsteer = (relativevector.x / relativevector.magnitude) * maxsteerangle;
        wheelFL.steerAngle = newsteer;
        wheelFR.steerAngle = newsteer;
    }
}
