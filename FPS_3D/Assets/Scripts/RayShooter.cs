using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    public UiController uiController;
    public AudioSource gunSound;

    Camera cam;

    public float fireRate;

    float fireTime = 0;

    // Start is called before the first frame update
    void Awake()
    {
        cam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        fireTime -= Time.deltaTime;
        if (uiController.firemode == "fullAuto")
        {
            if (Input.GetMouseButton(0))
            {
                if (fireTime <= 0 && uiController.ammoTotal > 0 && uiController.canShoot)
                {
                    Shoot();

                    fireTime = fireRate;
                }
                else
                {
                    Debug.Log("Can't shoot for some reason");
                }
            }
        }
        else if (uiController.firemode == "semiAuto")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (uiController.ammoTotal > 0 && uiController.canShoot)
                {
                    Shoot();
                }
                else
                {
                    Debug.Log("Can't shoot for some reason");
                }
            }
        }
        else
        {
            Debug.Log("Firemode not set properly");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            uiController.canShoot = false;
            Invoke("ChangeFireMode", 0.1f);
        }
    }

    //Places a sphere at a set of coords, then removes it (Expensive, change to use an object pool system)
    IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        sphere.transform.localScale = Vector3.one * 0.1f;

        sphere.transform.position = pos;

        yield return new WaitForSeconds(10);

        Destroy(sphere);
    }

    private void OnGUI()
    {
        int size = 16;

        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;

        GUI.Label(new Rect(posX, posY, size, size), "+");
    }

    void Shoot()
    {
        uiController.UpdateAmmoText(1);

        Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);

        Ray ray = cam.ScreenPointToRay(point);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            TargetController targetEnemy = hitObject.GetComponent<TargetController>();

            if (targetEnemy != null)
            {
                targetEnemy.ReactToHit();
            }
            else
            {
                StartCoroutine(SphereIndicator(hit.point));
            }
        }

        gunSound.Play();
    }

    void ChangeFireMode()
    {
        if (uiController.firemode == "semiAuto")
        {
            uiController.firemode = "fullAuto";
            uiController.UpdateFiremodeText();
        }
        else
        {
            uiController.firemode = "semiAuto";
            uiController.UpdateFiremodeText();
        }
        uiController.canShoot = true;
    }
}

