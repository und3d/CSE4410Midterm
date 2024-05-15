using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StartCourse : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    [SerializeField] UiController uiController;
    [SerializeField] Timer timer;

    public void Operate()
    {
        if (timer.courseActive == false)
        {
            
            for (int i = 0; i < sceneController.targetList.Count; i++)
            {
                sceneController.targetList[i].GetComponentInChildren<TargetController>().RaiseTarget();
            }

            uiController.standingTargets = sceneController.targetBoolList.Count;
            uiController.updateRemainingTargetsText(0);
            timer.courseActive = true;
            timer.elapsedTime = 0;
        }
    }
}
