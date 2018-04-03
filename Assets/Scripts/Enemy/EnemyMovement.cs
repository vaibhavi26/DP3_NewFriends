using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    
	public Transform thisObject;
	public Transform target;
	private UnityEngine.AI.NavMeshAgent navComponent;
	public float dist;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;

	void Start() 
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		navComponent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
		playerHealth = target.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <EnemyHealth> ();
	}

	void Update() 
	{

		dist = Vector3.Distance(target.position, transform.position);

		if(dist <= 30)
		{
			if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) 
			{
				navComponent.SetDestination (target.position);
			}
			else
			{
			    navComponent.enabled = true;
			}
			if (dist >= 30) {
				target = null;
			}
		}

		else
		{
			if(target = null)
			{
				target = this.gameObject.GetComponent<Transform>();
			}
			else
			{
				target = GameObject.FindGameObjectWithTag("Player").transform;
			}
		}
	}
}
