﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour {
    [SerializeField]
    [Tooltip("can we move up with elevator or not atm")]
    private bool canGoUp;

    [SerializeField]
    [Tooltip("can we move down with elevator or not atm")]
    private bool canMoveDown;

    [SerializeField]
    [Tooltip("are we up or down")]
    private bool positionChecked;
    // Use this for initialization
    void Start () {
        canGoUp = false;
        canMoveDown = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Game_Manager.instance.ElevatorMoving == 1 && canMoveDown)
        {
            Debug.Log("elevatorMovingdown");
            this.transform.Translate(Vector3.down * 0.25f);
            canGoUp = true;
        }
        if (Game_Manager.instance.ElevatorMoving == 2 && canGoUp)
        {
            Debug.Log("elevatorMovingUp");
            this.transform.Translate(Vector3.left * 0.25f);
            canMoveDown = false;
            
        }
        if (Game_Manager.instance.ElevatorMoving == 0)
        {
            Debug.Log("elevatorStill");
            while (!positionChecked)
            {
                if (canMoveDown)
                {
                    canMoveDown = false;
                }
                else
                {
                    canMoveDown = true;
                }

                if (canGoUp)
                {
                    canGoUp = false;
                }
                else
                {
                    canGoUp = true;
                }
                positionChecked = true;
            }
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ElevatorStopper"){
            Game_Manager.instance.ElevatorMoving = 0;
            Debug.Log("stopped");
        }
    }
}