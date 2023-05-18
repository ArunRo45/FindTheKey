using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class Player : MonoBehaviour
{
    public double playerCurrentTimeScore { get; private set; }

    private void Start()
    {
        PlayerInteract.OnPLayerWonFinalLevel += PlayerIntercat_OnPlayerWonFinalLevel;
    }

    private void PlayerIntercat_OnPlayerWonFinalLevel()
    {
        playerCurrentTimeScore = UiManager.instance.GetTotalTimeInSeconds();
        PlayerPrefs.SetInt(HelperScript.TOTAL_CURRENT_SCORE_VALUE, (int)playerCurrentTimeScore);
        print(playerCurrentTimeScore);
    }

    private void OnDisable()
    {
        PlayerInteract.OnPlayerWon -= PlayerIntercat_OnPlayerWonFinalLevel;
        //print("un subscribed");
    }

    

}
