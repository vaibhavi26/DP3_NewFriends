using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Move_1 : MonoBehaviour
{

    private GameObject target1;

    public float speed;
    public bool can_move = true;
    public bool can_iterate = true;

    // Use this for initialization
    void Start()
    {
     
        target1 = Camera.main.transform.GetChild(2).gameObject;

    }


    // Update is called once per frame
    void Update()
    {

        if (can_iterate)
        {
            if (can_move == true)
            {

                transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, speed * Time.deltaTime);


            }
            else if (can_move == false)
            {
                can_iterate = false;
            }
        }
    }
}
