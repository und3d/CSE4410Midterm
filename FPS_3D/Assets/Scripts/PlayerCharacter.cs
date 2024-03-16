using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    int health;
    public UiController uiController;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        uiController.UpdateHealthText(health);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for the lose condition (health reaches zero)
        if (health <= 0)
        {
            Debug.Log("You lose!");

            gameObject.SetActive(false);
        }
    }

    public void Hurt(int damage)
    {
        health -= damage;
        uiController.UpdateHealthText(health);
    }
}
