using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StartCourse : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    [SerializeField] UiController uiController;
    [SerializeField] Timer timer;

    [SerializeField] AudioClip error;
    [SerializeField] AudioClip success;

    AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Operate()
    {
        if (timer.courseActive == false)
        {
            audio.clip = success;
            audio.Play();

            for (int i = 0; i < sceneController.targetList.Count; i++)
            {
                sceneController.targetList[i].GetComponentInChildren<TargetController>().RaiseTarget();
            }

            uiController.standingTargets = sceneController.targetBoolList.Count;
            uiController.updateRemainingTargetsText(0);
            timer.courseActive = true;
            timer.elapsedTime = 0;
        }
        else
        {
            audio.clip = error;
            audio.Play();
        }
    }
}
