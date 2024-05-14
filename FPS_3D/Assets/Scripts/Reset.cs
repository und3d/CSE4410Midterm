using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // This function is called when the reset button is clicked
    public void ResetGame()
    {
        // Reset any game-specific variables or states here

        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
