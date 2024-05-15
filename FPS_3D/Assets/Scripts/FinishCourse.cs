using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FinishCourse : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
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
        if (timer.courseActive)
        {
            audio.clip = error;

            for (int i = 0; i < sceneController.targetBoolList.Count; i++)
            {
                if (sceneController.targetBoolList[i])
                {
                    Debug.Log("Not all targets hit");
                    audio.Play();
                    return;
                }
                else
                {
                    sceneController.courseComplete = true;
                }
            }

            if (sceneController.courseComplete)
            {
                audio.clip = success;
                audio.Play();
                timer.courseActive = false;
                timer.FastestTimeUpdate();
            }
        }
        else
        {
            audio.clip = error;
            audio.Play();
        }
    }
}
