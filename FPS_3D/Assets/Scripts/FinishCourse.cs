using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FinishCourse : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    [SerializeField] Timer timer;

    public void Operate()
    {
        if (timer.courseActive)
        {
            for (int i = 0; i < sceneController.targetBoolList.Count; i++)
            {
                if (sceneController.targetBoolList[i])
                {
                    Debug.Log("Not all targets hit");
                    return;
                }
                else
                {
                    sceneController.courseComplete = true;
                }
            }

            if (sceneController.courseComplete)
            {
                timer.courseActive = false;
                timer.FastestTimeUpdate();
            }
        }
    }
}
