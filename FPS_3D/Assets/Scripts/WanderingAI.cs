using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WanderingAI : MonoBehaviour
{
    [SerializeField] GameObject fireballPrefab;
    [SerializeField] GameObject explosionFirePrefab;
    GameObject explosion;
    GameObject fireball;


    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    public float enemyRange = 10.0f;

    bool isAlive;
    bool canShoot = true;
    public float detectionRange = 10.0f;
    private GameObject player;

    private void Start()
    {
        isAlive = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

            // chasing behavior towards player
            if (distance < detectionRange)
            {
                Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
                directionToPlayer.y = 0;
                transform.Translate(directionToPlayer * speed * Time.deltaTime, Space.World);


                // rotate towards the player, pretty smooth rotation
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0, directionToPlayer.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

                if (canShoot)
                {
                    canShoot = false;
                    Invoke("ToggleShoot", 1f);
                    ShootFireball();
                }
            }
            else
            {
                // return to old wandering state 
                transform.Translate(0, 0, speed * Time.deltaTime);

                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                if (Physics.SphereCast(ray, 0.75f, out hit, obstacleRange))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    if (hitObject.GetComponent<PlayerCharacter>())
                    {
                        if (fireball == null)
                        {
                            fireball = Instantiate(fireballPrefab) as GameObject;
                            fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                            fireball.transform.rotation = transform.rotation;
                        }
                    }
                    else if (hit.distance < obstacleRange)
                    {
                        float angle = Random.Range(-110, 110);
                        transform.Rotate(0, angle, 0);
                    }
                }
            }
        }
    }

    public void TakeDamage()
    {
        if (isAlive)
        {
            isAlive = false;
            Explode(); // Call Explode method when shot at
        }
    }

    void Explode()
    {
        if (explosion == null && explosionFirePrefab != null)
        {
            explosion = Instantiate(explosionFirePrefab, transform.position + Vector3.up, Quaternion.identity);
            Destroy(explosion, 3.0f); // Destroy the explosion effect after 3 seconds
            Destroy(gameObject); // Destroy the car enemy
        }
    }

    void ShootFireball()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit, enemyRange))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if (fireball == null)
                {
                    fireball = Instantiate(fireballPrefab) as GameObject;
                    fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    fireball.transform.position = new Vector3(fireball.transform.position.x, 1.113f, fireball.transform.position.z);
                    fireball.transform.rotation = transform.rotation;
                }
            }
        }
    }

    void ToggleShoot()
    {
        canShoot = true;
    }
}
