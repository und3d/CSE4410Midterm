using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UiController : MonoBehaviour
{
    [SerializeField] TMP_Text remainingTargets;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] TMP_Text firemodeText;
    [SerializeField] SceneController sceneController;

    public int standingTargets;

    public int ammoTotal;
    public bool canShoot = true;
    public string firemode = "semiAuto";

    private void Start()
    {
        ammoText.text = $"Ammo: {ammoTotal}";
        firemodeText.text = $"Firemode: {firemode}";
        standingTargets = 0;
    }

    public void updateRemainingTargetsText(int targetDropped)
    {
        standingTargets -= targetDropped;

        remainingTargets.text = $"Targets Remaining: {standingTargets}";
    }

    void AnnounceWin()
    {
        
        Debug.Log("You win!");
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
