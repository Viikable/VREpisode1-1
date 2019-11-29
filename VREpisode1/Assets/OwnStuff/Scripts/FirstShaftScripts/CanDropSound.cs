﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CanDropSound : MonoBehaviour {

    public AudioSource canDropSound;
   
	void Start () {
       
        canDropSound = transform.Find("CanDropSound").GetComponent<AudioSource>();
	}


    private void OnCollisionEnter(Collision collision)
    {
        if (!canDropSound.isPlaying && !gameObject.GetComponent<VRTK_InteractableObject>().IsGrabbed())
        {
        canDropSound.Play();
        }
    }
}