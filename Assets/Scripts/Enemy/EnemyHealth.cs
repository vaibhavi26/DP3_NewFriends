 using UnityEngine;
using System.Collections;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int startingHealth = 100;
    public int currentHealth;
	public int health =  100;
    Animator anim;
    void Awake ()
	{
        anim = GetComponent <Animator> ();
        currentHealth = startingHealth;
    }


    void Update ()
    {
       
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        currentHealth -= amount;
            
        if(currentHealth <= 0)
        {
            Death ();
			gameObject.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;

            Invoke("waitThreeSeconds", 10);

        }
    }
 
        void waitThreeSeconds(){
        Awake();
		gameObject.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = true;
        Debug.Log("After stop" + currentHealth);
      

    }

    void Death ()
    {

        anim.SetTrigger ("Dead");


    }


}
