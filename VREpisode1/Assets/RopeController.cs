﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GetComponent<ConfigurableJoint>().currentForce.magnitude >= 1100) {
            GetComponent<ConfigurableJoint>().breakForce = 0;
        }
	}
}