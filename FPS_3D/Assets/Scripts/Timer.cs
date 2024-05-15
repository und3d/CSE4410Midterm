using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float elapsedTime;
    public float highscoreTime;
    public int minutesElapsed;
    public int secondsElapsed;
    public int centiSecondsElapsed;

    public bool courseActive = false;

    public TMP_Text finalTimeText;
    public TMP_Text fastestTimeText;

    // Start is called before the first frame update
    void Awake()
    {
        elapsedTime = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (courseActive)
        {
            elapsedTime += Time.deltaTime;
            minutesElapsed = Mathf.FloorToInt(elapsedTime / 60);
            secondsElapsed = Mathf.FloorToInt(elapsedTime % 60);
            centiSecondsElapsed = Mathf.FloorToInt((elapsedTime % 1f) * 100);
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutesElapsed, secondsElapsed, centiSecondsElapsed);
        }
    }

    public void FastestTimeUpdate()
    {
        //Check if fastest time exists
        if (PlayerPrefs.HasKey("SavedFastestTime"))
        {
            //is new time faster than saved time?
            if (elapsedTime > PlayerPrefs.GetFloat("SavedFastestTime"))
            {
                //Set a new fastest time
                PlayerPrefs.SetFloat("SavedFastestTime", elapsedTime);
            }
        }
        else
        {
            //if there is no saved time, set it
            PlayerPrefs.SetFloat("SavedFastestTime", elapsedTime);
        }

        //Updating Text Objects
        minutesElapsed = Mathf.FloorToInt(elapsedTime / 60);
        secondsElapsed = Mathf.FloorToInt(elapsedTime % 60);
        centiSecondsElapsed = Mathf.FloorToInt((elapsedTime % 1f) * 100);
        finalTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutesElapsed, secondsElapsed, centiSecondsElapsed);

        highscoreTime = PlayerPrefs.GetFloat("SavedFastestTime");
        minutesElapsed = Mathf.FloorToInt(highscoreTime / 60);
        secondsElapsed = Mathf.FloorToInt(highscoreTime % 60);
        centiSecondsElapsed = Mathf.FloorToInt((highscoreTime % 1f) * 100);
        fastestTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutesElapsed, secondsElapsed, centiSecondsElapsed);
    }
}
