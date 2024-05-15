using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    //[SerializeField] GameObject enemyPrefab;
    [SerializeField] UiController uiController;

    //GameObject enemy;
    bool isReloading = false;
    public bool spawnCar = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (enemy == null)
        {
            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = new Vector3 (0, 0.11f, 0);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }*/

        if (Input.GetKeyDown(KeyCode.R) && !isReloading && uiController.ammoTotal < 31)
        {
            uiController.canShoot = false;
            isReloading = true;
            if (uiController.ammoTotal == 0)
            {
                Invoke("Reload", 2.5f);
            }
            else
            {
                Invoke("Reload", 2f);
            }
        }
    }

    void Reload()
    {
        if (uiController.ammoTotal == 0)
        {
            uiController.ammoTotal = 30;
            uiController.UpdateAmmoText(0);
        }
        else
        {
            uiController.ammoTotal = 31;
            uiController.UpdateAmmoText(0);
        }
        uiController.canShoot = true;
        isReloading = false;
    }
}
