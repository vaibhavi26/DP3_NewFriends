using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class ButtonCollider : MonoBehaviour {
	public UnityEvent onSpacebar;
	public UnityEvent onReturn;
	public PlayableDirector playableDirector;
    public MagicLightSource mg;
    private int signCheck;

   // GameObject particalGameobjectEnd;
   // GameObject particalGameobjectEnd1;
    public void Start()
    {
        //particalGameobjectEnd = GameObject.Find("EndObject").transform.GetChild(0).gameObject; 
      //  particalGameobjectEnd1 = GameObject.Find("EndObject").transform.GetChild(1).gameObject; 
    }

    public void OnTriggerStay ()
    {
        signCheck = GameObject.FindWithTag("Player").transform.GetChild(2).GetChild(0).GetComponent<MagicLightSource>().signCount;
        Debug.Log(signCheck);
        if (signCheck==1)
       {
		

				playableDirector.Play ();
				
			
		}

	}
    public void OnTriggerExit()
    {
        //particalGameobjectEnd.SetActive(false);
        //particalGameobjectEnd1.SetActive(false);
        Destroy(gameObject);
    }
}
