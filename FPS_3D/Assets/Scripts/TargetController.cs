using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public int score = 1;
    public SceneController sceneController;
    public UiController uiController;
    public GameObject targetPivot;
    public GameObject explosionPrefab;

    bool canBeHit = false;
    public int objectID = -1;

    private void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
        uiController = FindObjectOfType<UiController>();
        targetPivot.transform.Rotate(90, 0, 0);
    }

    public void ReactToHit()
    {
        if (!canBeHit)
        {
            return;
        }

        Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
        LowerTarget();
    }

    public void LowerTarget()
    {
        canBeHit = false;
        targetPivot.transform.Rotate(90, 0, 0);

        if (sceneController == null || uiController == null)
        {
            Debug.LogError("Object of SceneController or UiController not found");
            return;
        }

        sceneController.targetBoolList[objectID] = false;
        uiController.updateRemainingTargetsText(1);
    }

    public void RaiseTarget()
    {
        targetPivot.transform.Rotate(-90, 0, 0);
        canBeHit = true;

        if (sceneController == null)
        {
            Debug.LogError("Object of SceneController not found");
            return;
        }

        sceneController.targetBoolList[objectID] = true;
    }
}
