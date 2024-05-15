using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] UiController uiController;
    public List<GameObject> targetList = new List<GameObject>();
    public List<bool> targetBoolList = new List<bool>();

    bool isReloading = false;
    public bool courseComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (GameObject target in targetList)
        {
            target.GetComponentInChildren<TargetController>().objectID = i;
            i++;
            targetBoolList.Add(target);
        }
    }

    // Update is called once per frame
    void Update()
    {

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
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
