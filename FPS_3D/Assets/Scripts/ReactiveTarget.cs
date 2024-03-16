using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ReactiveTarget : MonoBehaviour
{
    public int score = 1;
    public UiController uiController;

    private void Start()
    {
        uiController = FindObjectOfType<UiController>();
    }

    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }

        StartCoroutine(Die());
    }

    public IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);
        if (uiController != null)
        {
            uiController.updateScoreText(score);
        }

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
