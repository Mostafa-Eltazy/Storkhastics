using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour {

    public Transform path;
    public float maxsteerangle = 45f;
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
