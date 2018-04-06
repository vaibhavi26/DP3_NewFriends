using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MagicLightSource : MonoBehaviour
{
    private GameObject target;
    Ray shootRay_m = new Ray();
    Ray shootRay_1 = new Ray();
    Ray shootRay_2 = new Ray();
    RaycastHit shootHit_m;
    RaycastHit shootHit_1;
    RaycastHit shootHit_2;
    int shootableMask;
    public float range = 100f;




    public Material reveal;
    public Light flashlight;
    GameObject ChildGameObject1;
    GameObject ChildGameObject0;
    GameObject QuadObject;
    
    private GameObject particalGameobject;
    private GameObject particalGameobjectDestroy;
    private Vector3 instantiatePosition;
    private GameObject destroyedObject;
    public int signCount=0;

    GameObject endObject;
    private bool destroyFlag=false;

    // public string check;




    // Use this for initialization
    void Start()
    {

        QuadObject = GameObject.Find("Quad_Moon");
       
        ChildGameObject1 = Camera.main.transform.GetChild(1).gameObject;
        ChildGameObject0 = Camera.main.transform.GetChild(0).gameObject;
        
        instantiatePosition = new Vector3(QuadObject.transform.position.x, QuadObject.transform.position.y, QuadObject.transform.position.z);
       
        ChildGameObject1.SetActive(false);
       
        particalGameobject = QuadObject.transform.GetChild(0).gameObject; particalGameobject.SetActive(false);
        particalGameobjectDestroy = QuadObject.transform.GetChild(1).gameObject; particalGameobjectDestroy.SetActive(false);

        // particalGameobjectEnd = GameObject.Find("EndObject").transform.GetChild(0).gameObject; particalGameobjectEnd.SetActive(false);
        //particalGameobjectEnd1 = GameObject.Find("EndObject").transform.GetChild(1).gameObject; particalGameobjectEnd1.SetActive(false);
        endObject = GameObject.Find("Cube");
        endObject.SetActive(false);


    }



    void Awake()
    {
        shootableMask = LayerMask.GetMask("Invisible");



    }

    // Update is called once per frame
    void Update()
    {
        //reveal sign
        reveal.SetVector("_LightPosition", flashlight.transform.position);
        reveal.SetVector("_LightDirection", -flashlight.transform.forward);
        reveal.SetFloat("_LightAngle", flashlight.spotAngle);

        //three raycast
        float totalFOV = 30.0f;
        float rayRange = 10.0f;
        float halfFOV = totalFOV / 2.0f;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, Vector3.left);
        Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, Vector3.left);
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;

        shootRay_m.origin = transform.position;
        shootRay_m.direction = transform.forward;

        shootRay_1.origin = transform.position;
        shootRay_1.direction = leftRayDirection * rayRange;

        shootRay_2.origin = transform.position;
        shootRay_2.direction = rightRayDirection * rayRange;

        //UI ANimate

        if (Physics.Raycast(shootRay_2, out shootHit_2, range, shootableMask))
        {
            destroyedObject = shootHit_2.transform.gameObject; particleEffect();
            if (Input.GetMouseButtonDown(0))
            {
                if (Input.mousePosition.x >= Screen.width / 2)
                {
                    Invoke("Destroy1", 0.5f);
                    moveUI();
                }
                

            }


        }

        else if (Physics.Raycast(shootRay_1, out shootHit_1, range, shootableMask))
        {
            destroyedObject = shootHit_1.transform.gameObject; particleEffect();

            if (Input.GetMouseButtonDown(0))
            {
                if (Input.mousePosition.x >= Screen.width / 2)
                {
                    Invoke("Destroy2", 0.5f);
                    moveUI();
                }

            }


        }
        else if (Physics.Raycast(shootRay_m, out shootHit_m, range, shootableMask))
        {
            destroyedObject = shootHit_m.transform.gameObject; particleEffect();
            if (Input.GetMouseButtonDown(0))
            {
                if (Input.mousePosition.x >= Screen.width / 2)
                {
                    Invoke("Destroy3", 0.5f);

                    Debug.Log("hitObject" + destroyedObject);
                    moveUI();
                }
            }


        }
        else
            noParticleEffect();


    }
    public void Destroy1()
    {
        Debug.Log("Destroyed by 1st ray");
        Destroy(shootHit_2.transform.gameObject); signCount = signCount + 1;
        endObject.SetActive(true); 
        //  particalGameobjectEnd1.SetActive(true); particalGameobjectEnd.SetActive(true);
    }
    public void Destroy2()
    {
        Debug.Log("Destroyed by 2nd ray");
        Destroy(shootHit_1.transform.gameObject); signCount = signCount + 1;
        endObject.SetActive(true);
        //particalGameobjectEnd1.SetActive(true); particalGameobjectEnd.SetActive(true);
    }
    public void Destroy3()
    {
        Debug.Log("Destroyed by mid ray");
        Destroy(shootHit_m.transform.gameObject); signCount = signCount + 1;
        endObject.SetActive(true); 
        // particalGameobjectEnd1.SetActive(true); particalGameobjectEnd.SetActive(true);
    }
    private void particleEffect()
    {
        if (destroyedObject.name == "Quad_Moon")
        {
            Behaviour halo = (Behaviour)QuadObject.GetComponent("Halo");
            halo.enabled = true;
            particalGameobject.SetActive(true);
        }
        
    }
    private void noParticleEffect()
    {
        if (QuadObject)
        {
            Behaviour halo = (Behaviour)QuadObject.GetComponent("Halo");
            halo.enabled = false;
            particalGameobject.SetActive(false);
        }


    }
    private void moveUI()
    {
        if (destroyedObject.name == "Quad_Moon")
        {
            particalGameobjectDestroy.SetActive(true);
            //check = "Quad_Moon";
            ChildGameObject1.SetActive(true);

            GameObject toMove = Instantiate(ChildGameObject1, instantiatePosition, Quaternion.identity); ChildGameObject0.SetActive(false);
            



        }
        

    }


    public void OnDrawGizmos()
    {
        Gizmos.DrawRay(shootRay_m.origin, shootRay_m.direction * 100);
        Gizmos.DrawRay(shootRay_1.origin, shootRay_1.direction * 100);
        Gizmos.DrawRay(shootRay_2.origin, shootRay_2.direction * 100);

    }



}
