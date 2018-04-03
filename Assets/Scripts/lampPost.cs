using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampPost : MonoBehaviour
{
    Light lampLight;


       public int damagePerShot = 120;
       public float range = 100f;
       public EnemyHealth enemyHealth1;

       Ray lampRay = new Ray();
       Ray lampRay_1 = new Ray();
       Ray lampRay_2= new Ray();
    Ray lampRay_3 = new Ray();
    Ray lampRay_4 = new Ray();
    Ray lampRay_5 = new Ray();


    RaycastHit lampHit;
       RaycastHit lampHit_1;
       RaycastHit lampHit_2;
    RaycastHit lampHit_3;
    RaycastHit lampHit_4;
    RaycastHit lampHit_5;
    int shootableMask;


       void Awake()
       {

           shootableMask = LayerMask.GetMask("Shootable");

       }

    void Start()
    {
        lampLight = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    // Update is called once per frame
    void Update()
    {
    
        Quaternion left = Quaternion.AngleAxis(5.0f, Vector3.left);
        Quaternion right = Quaternion.AngleAxis(5.0f, Vector3.right);
        Quaternion up = Quaternion.AngleAxis(110.0f, Vector3.up);
        Quaternion upRight = Quaternion.AngleAxis(270.0f, Vector3.up);
        Quaternion upRight1 = Quaternion.AngleAxis(-70.0f, Vector3.left);


        Vector3 leftRayDirection = left * transform.forward;
        Vector3 rightRayDirection = right * transform.forward;
        Vector3 upRayDirection = up * transform.forward * 5.0f;
        Vector3 upRayDirection1 = upRight * transform.forward * 5.0f;
       // Vector3 upRayDirection2 = upRight1 * transform.forward;

        lampRay.origin = transform.position;
        lampRay.direction = transform.forward;

        lampRay_1.origin = transform.position;
        lampRay_1.direction = leftRayDirection * 10.0f;

        lampRay_2.origin = transform.position;
        lampRay_2.direction = rightRayDirection * 10.0f;

        lampRay_3.origin = transform.position;
        lampRay_3.direction = upRayDirection * 10.0f;

        lampRay_4.origin = transform.position;
        lampRay_4.direction = upRayDirection1 * 10.0f;

        lampRay_5.origin = transform.position;
        lampRay_5.direction = upRayDirection1 * 10.0f;


        if (lampLight.enabled)
        {
              Shoot();
            Debug.Log("ON" + lampLight);
        }
        else if(!lampLight.enabled)
        {
             //notShoot();
            Debug.Log("OFF" + lampLight);
        }

    }
    void Shoot()
    {


        lampRay.origin = transform.position;
        lampRay.direction = transform.forward;

        if (Physics.Raycast(lampRay, out lampHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = lampHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, lampHit.point);
                Debug.Log("Hit on Enemy");

            }

        }

        else
         if (Physics.Raycast(lampRay_1, out lampHit_1, range, shootableMask))
        {
            EnemyHealth enemyHealth = lampHit_1.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, lampHit.point);
                Debug.Log("Hit on Enemy1");

            }

        }
        else
         if (Physics.Raycast(lampRay_2, out lampHit_2, range, shootableMask))
        {
            EnemyHealth enemyHealth = lampHit_2.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, lampHit.point);
                Debug.Log("Hit on Enemy2");

            }

        }
        else
         if (Physics.Raycast(lampRay_3, out lampHit_3, range, shootableMask))
        {
            EnemyHealth enemyHealth = lampHit_3.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, lampHit.point);
                Debug.Log("Hit on Enemy2");

            }

        }
        else
         if (Physics.Raycast(lampRay_4, out lampHit_4, range, shootableMask))
        {
            EnemyHealth enemyHealth = lampHit_4.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, lampHit.point);
                Debug.Log("Hit on Enemy2");

            }

        }
        else
         if (Physics.Raycast(lampRay_5, out lampHit_5, range, shootableMask))
        {
            EnemyHealth enemyHealth = lampHit_5.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, lampHit.point);
                Debug.Log("Hit on Enemy2");

            }

        }

    }




    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);
            lampLight.enabled = !lampLight.enabled;
        

        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawRay(lampRay.origin, lampRay.direction * 100);
        Gizmos.DrawRay(lampRay_1.origin, lampRay_1.direction * 100);
        Gizmos.DrawRay(lampRay_2.origin, lampRay_2.direction * 100);
        Gizmos.DrawRay(lampRay_3.origin, lampRay_3.direction * 100);
        Gizmos.DrawRay(lampRay_4.origin, lampRay_4.direction * 100);
        Gizmos.DrawRay(lampRay_5.origin, lampRay_5.direction * 100);
    }


  
}

