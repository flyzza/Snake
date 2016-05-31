using UnityEngine;
using System.Collections;

public class CemaraLookAt : MonoBehaviour {

    Transform target;
	// Use this for initialization
	void Start () {

        ////target = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 newPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position = newPos;
	
	}
}
