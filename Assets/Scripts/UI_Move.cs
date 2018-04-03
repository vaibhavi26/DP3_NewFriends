using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Move : MonoBehaviour {

    private GameObject target;
 //   private GameObject target1;
 //   private GameObject destroyedGameObject;
    public float speed;
    public bool can_move=true;
    public bool can_iterate = true;
   
    // Use this for initialization
    void Start () {
       // destroyedGameObject = GameObject.FindWithTag("Player").transform.GetChild(2).gameObject.GetComponent<MagicLightSource>().destroyedObject;
     
        target = Camera.main.transform.GetChild(0).gameObject; 
       
    }


    // Update is called once per frame
    void Update()
    {

        if (can_iterate)
        {   
            if (can_move==true)
            {
                
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
             
               
            }
            else if(can_move==false)
            {
                can_iterate = false;
            }
        }
    }
}
