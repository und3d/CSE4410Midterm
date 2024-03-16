using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    int health;
    public UiController uiController;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        uiController.UpdateHealthText(health);
    }

    public void Hurt(int damage)
    {
        health -= damage;
        uiController.UpdateHealthText(health);
    }
}
