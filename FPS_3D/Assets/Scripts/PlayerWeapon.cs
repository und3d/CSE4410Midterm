using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30;
    public float lifeTime = 3;
    public AudioSource gunSound; // Reference to the AudioSource
    public GameObject explosionPrefab; // Reference to the explosion prefab

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Play the gun sound effect
        if (gunSound != null)
        {
            gunSound.Play();
        }
        else
        {
            Debug.LogWarning("Gun sound AudioSource is not assigned!");
        }

        // Instantiate bullet
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = bulletSpawn.position;
        bullet.transform.rotation = bulletSpawn.rotation;
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;

        // Destroy the bullet after a certain time
        Destroy(bullet, lifeTime);
    }

    // Called when a bullet hits an object
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Instantiate explosion effect
            Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);

            // Play sound effect
            // Add code to play the sound effect here
        }
    }
}