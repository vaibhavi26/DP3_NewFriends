using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot1 = 20;
    public int damagePerShot2 = 30;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
  

    float timer;
    Ray shootRay = new Ray();

    Ray breakingRay = new Ray();
    RaycastHit shootHit;
    RaycastHit breakHit;
    int shootableMask; int breakableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;


    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        breakableMask = LayerMask.GetMask("breakableObject");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }


   void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }

        /* timer += Time.deltaTime;

         if (Input.GetButtonDown("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
         {
             if (Input.mousePosition.x >= Screen.width / 2)
             {


                 Shoot();
             }
         }

         if (timer >= timeBetweenBullets * effectsDisplayTime)
         {
             DisableEffects();
         }*/
    }

    public void onShootClick()
        {
       
                if(timer >= timeBetweenBullets && Time.timeScale != 0)
                {
                    Shoot();
                }

           

             
        }

       


    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        breakingRay.origin = transform.position;
        breakingRay.direction = transform.forward;
        if (Physics.Raycast(breakingRay, out breakHit, range, breakableMask))
        {
            Debug.Log("In breakable MAsk");
            breakableCube breakingHealth = breakHit.collider.GetComponent<breakableCube>();
            if (breakingHealth != null)
            {
                breakingHealth.TakeDamage(damagePerShot1, breakHit.point);
                Debug.Log("Before breaking" + breakingHealth.currentbreakingHealth);

            }
            gunLine.SetPosition(1, breakHit.point);
        }
        else if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            Debug.Log("In shootable MAsk");
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot2, shootHit.point);
                Debug.Log("Before stop" + enemyHealth.currentHealth);

            }

            gunLine.SetPosition(1, shootHit.point);

        }

        else
        {

            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }

    }



}
