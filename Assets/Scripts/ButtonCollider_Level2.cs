﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class ButtonCollider_Level2 : MonoBehaviour
{
    public PlayableDirector playableDirector;
  //  public MagicLightSource mg1;
    private int signCheck;
    
    public void Start()
    {
    }

    public void OnTriggerStay()
    {
        signCheck = GameObject.FindWithTag("Player").transform.GetChild(2).GetChild(0).GetComponent<MagicLightSource_Level2>().signCount;
        Debug.Log("Number12:" + signCheck);
        if (signCheck == 2)
        {
            Debug.Log("Number:" + signCheck);
            playableDirector.Play();
        }

    }
    public void OnTriggerExit()
    {
        Destroy(gameObject);
    }
}
