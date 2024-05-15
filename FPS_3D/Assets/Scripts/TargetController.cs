using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public int score = 1;
    public UiController uiController;
    public GameObject targetPivot;
    public GameObject explosionPrefab;

    bool canBeHit = true;

    private void Start()
    {
        uiController = FindObjectOfType<UiController>();
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
        if (uiController != null)
        {
            uiController.updateScoreText(score);
        }

    }
}
