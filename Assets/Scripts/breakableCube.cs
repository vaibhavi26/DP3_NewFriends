using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableCube : MonoBehaviour {
    public int startingHealth = 100;
    public int currentbreakingHealth;


    public GameObject destructedVersion;
    public PlayerShooting ps;

    void Awake()
    {
       

        currentbreakingHealth = startingHealth;

    }


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int amount_Hit, Vector3 hitPoint)
    {

        

        currentbreakingHealth = currentbreakingHealth-amount_Hit;
        Debug.Log("currentbreakingHealth = currentbreakingHealth-amount;" + currentbreakingHealth);



        if (currentbreakingHealth <= 0)
        {
            Debug.Log("BRAEAK BOX");
            Instantiate(destructedVersion,transform.position,transform.rotation);
            Destroy(gameObject, 0.2f);


        }
    }

}
