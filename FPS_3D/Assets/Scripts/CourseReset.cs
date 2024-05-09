using UnityEngine;
using UnityEngine.SceneManagement;

public class CourseReset : MonoBehaviour
{
    public string levelToLoad = "YourLevelName"; // Change this to the name of your level scene

    public void ResetCourse()
    {
        SceneManager.LoadScene(levelToLoad); // Load the specified level
    }
}
