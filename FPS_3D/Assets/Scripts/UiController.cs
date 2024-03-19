using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UiController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] TMP_Text firemodeText;

    int scoreTotal;
    int healthTotal;

    public int ammoTotal;
    public bool canShoot = true;
    public string firemode = "semiAuto";

    private void Start()
    {
        ammoText.text = $"Ammo: {ammoTotal}";
        firemodeText.text = $"Firemode: {firemode}";
    }

    public void updateScoreText(int score)
    {
        scoreTotal += score;

        scoreText.text = $"Score: {scoreTotal}";

        // Check if the score reaches 3
        if (scoreTotal >= 3)
        {
            // Call a method to announce the win
            AnnounceWin();
        }
    }

    void AnnounceWin()
    {
        
        Debug.Log("You win!");
    }

    public void UpdateHealthText(int health)
    {
        healthText.text = $"Heath: {health}";
    }

    public void UpdateAmmoText(int ammo)
    {
        ammoTotal -= ammo;
        ammoText.text = $"Ammo: {ammoTotal}";
    }

    public void UpdateFiremodeText()
    {
        firemodeText.text = $"Firemode: {firemode}";
    }
}
