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

    int scoreTotal;
    int healthTotal;

    public int ammoTotal;

    private void Start()
    {
        ammoText.text = $"Ammo: {ammoTotal}";
    }

    public void updateScoreText(int score)
    {
        scoreTotal += score;

        scoreText.text = $"Score: {scoreTotal}";
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
}
