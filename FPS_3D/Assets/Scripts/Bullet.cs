using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Speed of the bullet
    public float speed = 10f;

    // Damage inflicted by the bullet
    public int damage = 1;

    // Lifetime of the bullet (in seconds)
    public float lifetime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Destroy the bullet after its lifetime expires
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bullet forward based on its speed
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet collided with an object that can take damage
        // You might want to add layers or tags to differentiate between different types of objects
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Get the health component of the enemy
            Health enemyHealth = collision.gameObject.GetComponent<Health>();

            // If the enemy has a health component, apply damage
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }

        // Destroy the bullet on collision with any object
        Destroy(gameObject);
    }
}

