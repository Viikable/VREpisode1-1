﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;

public class ConveyorBeltController : MonoBehaviour {
    Animator anim;

    Animator anim2;

    Animator anim3;

    AudioSource ConveyorAudio;

    AudioSource ConveyorAudio2;

    AudioSource ConveyorAudio3;

    Animator animDown;

    GameObject Screen1Button;

    GameObject Screen2Button;

    GameObject Screen3Button;

    [SerializeField]
    [Tooltip("Is the conveyor belt animation playing or not")]
    private bool NotPlaying = true;
    [SerializeField]
    [Tooltip("Has the player triggered the moving of the conveyor belts")]
    private bool PressedScreen1 = false;
    [SerializeField]
    [Tooltip("Has the player triggered the moving of the conveyor belt so it lowers down to the pool")]
    private bool PressedScreen2 = false;
    [SerializeField]
    [Tooltip("Has the player paused the movement of the conveyor belts")]
    private bool PressedScreen3 = false;
    // Use this for initialization
    void Start () {
        ConveyorAudio = GameObject.Find("ConveyorAudio").GetComponent<AudioSource>();
        ConveyorAudio2 = GameObject.Find("ConveyorAudio2").GetComponent<AudioSource>();
        ConveyorAudio3 = GameObject.Find("ConveyorAudio3").GetComponent<AudioSource>();
        anim = GameObject.Find("Conveyor_belt_Animated").GetComponent<Animator>();
        anim2 = GameObject.Find("Conveyor_belt_Animated2").GetComponent<Animator>();
        anim3 = GameObject.Find("Conveyor_belt_Animated3").GetComponent<Animator>();
        animDown = GameObject.Find("Conveyor_belt_AnimatedDown").GetComponent<Animator>();
        Screen1Button = GameObject.Find("Screen1Button");
        Screen2Button = GameObject.Find("Screen2Button");
        Screen3Button = GameObject.Find("Screen3Button");
    }
    public bool GetNotPlaying()
    {
        return NotPlaying;
    }
    public void SetNotPlaying(bool wtf)
    {
        NotPlaying = wtf;
    }
    public void SetPressedScreen1On()
    {
        PressedScreen1 = true;
    }
    public bool GetPressedScreen1()
    {
        return PressedScreen1;
    }
    public void SetPressedScreen2On()
    {
        PressedScreen2 = true;
    }
    public bool GetPressedScreen3()
    {
        return PressedScreen3;
    }
    public void SetPressedScreen3On()
    {
        PressedScreen3 = true;
    }

    public void CheckButtonPress()    //to see when the buttons controlling the conveyor belts are pressed down
    {
        if (Screen1Button.GetComponent<VRTK_PhysicsPusher>().PressedDown && !PressedScreen1)
        {
            Debug.Log("pressed1");
            PressedScreen1 = true;
            //PressedScreen3 = false;
            Screen1Button.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
            if (Screen3Button.GetComponent<VRTK_PhysicsPusher>().PressedDown)
            {
                Debug.Log("pressed1while3");
                Screen3Button.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            }
        }
        if (Screen2Button.GetComponent<VRTK_PhysicsPusher>().PressedDown && !PressedScreen2)
        {
            Debug.Log("pressed2");
            PressedScreen2 = true;
        }
        if (Screen3Button.GetComponent<VRTK_PhysicsPusher>().PressedDown && !PressedScreen3)
        {
            Debug.Log("pressed3");
            PressedScreen3 = true;
            //PressedScreen1 = false;
            Screen3Button.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
            if (Screen1Button.GetComponent<VRTK_PhysicsPusher>().PressedDown)
            {
                Screen1Button.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
                Debug.Log("pressed3while1");
            }
        }
    }
    // Update is called once per frame
    void Update () {
        //StopAllCoroutines();
        CheckButtonPress();

        if (PressedScreen1)
        {
            //starts the sound and movement for all normal conveyorbelts
            if (NotPlaying)
            {
                NotPlaying = false;
                ConveyorAudio.Play();
                ConveyorAudio2.Play();
                ConveyorAudio3.Play();

                anim.SetBool("Start", true);
                anim2.SetBool("Start", true);
                anim3.SetBool("Start", true);
                anim.speed = 2f;
                anim2.speed = 2f;
                anim3.speed = 2f;
                animDown.speed = 2f;
                StartCoroutine("JustASec");
                PressedScreen3 = false;                
            }
        }
        
        if (PressedScreen2)
        {
            //makes the middle conveyor belt go down 
            anim.SetBool("Open", true);
            animDown.SetBool("Open", true);
            
        }
        if (PressedScreen3)
        {
            //stops the sound and movement of all conveyorbelts
            if (!NotPlaying)
            {
                anim.speed = 0f;
                anim2.speed = 0f;
                anim3.speed = 0f;
                animDown.speed = 0f;
                ConveyorAudio.Stop();
                ConveyorAudio2.Stop();
                ConveyorAudio3.Stop();
                NotPlaying = true;
                StartCoroutine("JustASec");
                PressedScreen1 = false;                
            }            
        }
        
        //if (PressedScreen3)
        //{
        //   //melt the metal animation

        //}
    }
    IEnumerator JustASec()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("wait");
        Screen1Button.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
        Screen3Button.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
        yield break;
    }
}
