using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MagicLightSource_Level2: MonoBehaviour
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
    public Material reveal1;
    public Light flashlight;
    GameObject ChildGameObject1;
    GameObject ChildGameObject0;
    GameObject QuadObject;
    GameObject ChildGameObject2;
    GameObject ChildGameObject3;
    GameObject QuadObject1;

    private GameObject particalGameobject;
    private GameObject particalGameobjectDestroy;
    private GameObject particalGameobject1;
    private GameObject particalGameobjectDestroy1;
    private Vector3 instantiatePosition; private Vector3 instantiatePosition1;
    private GameObject destroyedObject;
    public int signCount;

    GameObject endObject;

     public string check;




    // Use this for initialization
    void Start()
    {
        signCount = 0;
        QuadObject = GameObject.Find("Quad_Pallas");
        QuadObject1 = GameObject.Find("Quad_Ceres");
        ChildGameObject1 = Camera.main.transform.GetChild(1).gameObject;
        ChildGameObject0 = Camera.main.transform.GetChild(0).gameObject;
        ChildGameObject2 = Camera.main.transform.GetChild(2).gameObject;
        ChildGameObject3 = Camera.main.transform.GetChild(3).gameObject;

        instantiatePosition = new Vector3(QuadObject.transform.position.x, QuadObject.transform.position.y, QuadObject.transform.position.z);
        instantiatePosition1 = new Vector3(QuadObject1.transform.position.x, QuadObject1.transform.position.y, QuadObject1.transform.position.z);

        ChildGameObject1.SetActive(false);
        ChildGameObject3.SetActive(false);

        particalGameobject = QuadObject.transform.GetChild(0).gameObject; particalGameobject.SetActive(false);
        particalGameobjectDestroy = QuadObject.transform.GetChild(1).gameObject; particalGameobjectDestroy.SetActive(false);
        particalGameobject1 = QuadObject1.transform.GetChild(0).gameObject; particalGameobject1.SetActive(false);
        particalGameobjectDestroy1 = QuadObject1.transform.GetChild(1).gameObject; particalGameobjectDestroy1.SetActive(false);

        // particalGameobjectEnd = GameObject.Find("EndObject").transform.GetChild(0).gameObject; particalGameobjectEnd.SetActive(false);
        //particalGameobjectEnd1 = GameObject.Find("EndObject").transform.GetChild(1).gameObject; particalGameobjectEnd1.SetActive(false);
        endObject = GameObject.Find("Cube_Level2");
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
        reveal1.SetVector("_LightPosition", flashlight.transform.position);
        reveal1.SetVector("_LightDirection", -flashlight.transform.forward);
        reveal1.SetFloat("_LightAngle", flashlight.spotAngle);


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
                    moveUI();
                }
            }


        }
        else
            noParticleEffect();


    }
    public void Destroy1()
    {
        Destroy(shootHit_2.transform.gameObject);
        if (signCount <2) signCount++;
        if (signCount == 2)
        {
            endObject.SetActive(true);
        }

    }
    public void Destroy2()
    {
        Destroy(shootHit_1.transform.gameObject);
        if (signCount < 2) signCount++;
        if (signCount == 2)
        {
            endObject.SetActive(true);
        }
     
    }
    public void Destroy3()
    {
        Destroy(shootHit_m.transform.gameObject);
        if(signCount<2)signCount++;
        if (signCount == 2)
        {
            endObject.SetActive(true);
        }
    }
        
    private void particleEffect()
    {
        if (destroyedObject.name == "Quad_Pallas")
        {
            Behaviour halo = (Behaviour)QuadObject.GetComponent("Halo");
            halo.enabled = true;
            particalGameobject.SetActive(true);
        }
        else if (destroyedObject.name == "Quad_Ceres")
        {
            Behaviour halo1 = (Behaviour)QuadObject1.GetComponent("Halo");
            halo1.enabled = true;
            particalGameobject1.SetActive(true);
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
        else if(QuadObject1)
        {
            Behaviour halo1 = (Behaviour)QuadObject1.GetComponent("Halo");
            halo1.enabled = false; particalGameobject1.SetActive(false);
        }

    }
    private void moveUI()
    {
        if (destroyedObject.name == "Quad_Pallas")
        {
            particalGameobjectDestroy.SetActive(true);
            //check = "Quad_Pallas";
            ChildGameObject1.SetActive(true);

            GameObject toMove = Instantiate(ChildGameObject1, instantiatePosition, Quaternion.identity);
            ChildGameObject0.SetActive(false);
        }
        else if (destroyedObject.name == "Quad_Ceres")
        {
            particalGameobjectDestroy1.SetActive(true);
           // check = "Quad_Ceres";
            ChildGameObject3.SetActive(true);

            GameObject toMove1 = Instantiate(ChildGameObject3, instantiatePosition1, Quaternion.identity);
            ChildGameObject2.SetActive(false);
        }


    }


    public void OnDrawGizmos()
    {
        Gizmos.DrawRay(shootRay_m.origin, shootRay_m.direction * 100);
        Gizmos.DrawRay(shootRay_1.origin, shootRay_1.direction * 100);
        Gizmos.DrawRay(shootRay_2.origin, shootRay_2.direction * 100);

    }



}
