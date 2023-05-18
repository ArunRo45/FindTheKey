using UnityEngine;

public class SaveManager : MonoBehaviour
{

    private int finishedLevelIndex = 1;
    private void Start()
    {
        PlayerInteract.OnPlayerWon += OnPLayerWon;
    }

    private void OnPLayerWon()
    {
        SaveCoins();
        //SaveScene();
    }

    private void SaveCoins()
    {
        GameHandler.instance.totalCoins += GameHandler.instance.Coins;
        PlayerPrefs.SetInt(HelperScript.PLYAER_COINS_KEY, GameHandler.instance.totalCoins);
        // Debug.Log("CurrentScene Coins Colleted : "+ GameHandler.instance.Coins);
        // Debug.Log("Total Coins Colleted : " + GameHandler.instance.totalCoins);
    }

    private void SaveScene()
    {
        finishedLevelIndex = UiManager.instance.CurrentSceneIndex;
        PlayerPrefs.SetInt(HelperScript.SAVE_SCENE_NAME_KEY, finishedLevelIndex);
        Debug.Log("Saved Scene Index : " + PlayerPrefs.GetInt(HelperScript.SAVE_SCENE_NAME_KEY));
    }
}
