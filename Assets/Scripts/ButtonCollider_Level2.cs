using System.Collections;
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
       
        if (signCheck == 2)
        {
            playableDirector.Play();
        }

    }
    public void OnTriggerExit()
    {
        Destroy(gameObject);
    }
}
