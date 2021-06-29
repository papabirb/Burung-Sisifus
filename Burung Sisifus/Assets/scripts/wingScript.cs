using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wingScript : MonoBehaviour {

    public int wingFlap = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(new Vector3(0, 0, wingFlap));
        }
        if (Input.GetKeyUp(KeyCode.Space)) {

            transform.Rotate(new Vector3(0, 0, -wingFlap));
        }
    }
}
