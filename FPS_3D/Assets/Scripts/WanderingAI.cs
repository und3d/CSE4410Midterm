using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] GameObject explosionFirePrefab;
    GameObject explosion;

    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    bool isAlive = true;
    void Update()
    {
        if (isAlive)
        {
      transform.Translate(0, 0, speed * Time.deltaTime);

         Ray ray = new Ray(transform.position, transform.forward);
         
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    TakeDamage(); // Call TakeDamage method when shot at
                }

                if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
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
}

