﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ShaftTopOpening : MonoBehaviour
{
    VRTK_SnapDropZone ShaftTopZone;
    Animator TopShaftHatch;
    bool notOpen;
    SkeletonKey SecondShaftKeyCard;
    AudioSource DamagedKeyCardSound;
    public Light TalosPuzzleLight;

    void Start()
    {
        ShaftTopZone = GetComponent<VRTK_SnapDropZone>();
        TopShaftHatch = GameObject.Find("GateShaftEnd").GetComponent<Animator>();
        notOpen = true;
        SecondShaftKeyCard = GameObject.Find("ShaftKey").GetComponent<SkeletonKey>();
        DamagedKeyCardSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (ShaftTopZone.GetCurrentSnappedObject() != null && notOpen)
        {
            if (!SecondShaftKeyCard.IsDamagedByWater())
            {
                TopShaftHatch.SetBool("Open", true);
                notOpen = false;
                TalosPuzzleLight.enabled = true;
            }
            else
            {
                DamagedKeyCardSound.Play();
            }
        }
    }
}
