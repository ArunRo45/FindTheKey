using System;
using TMPro;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _titleText;



    private string titleName;

    private void Start()
    {
        _coinsText.SetText("COINS : "+ PlayerPrefs.GetInt(HelperScript.PLYAER_COINS_KEY));
    }



    public void getTitleText(string titleName)
    {
        var request = new GetTitleDataRequest();
        this.titleName = titleName;
        PlayFabClientAPI.GetTitleData(request, OnSuccess, OnError);
    }

    private void OnSuccess(GetTitleDataResult result)
    {
        if (result == null && result.Data.ContainsKey(titleName) == false)
            return;

        _titleText.SetText(result.Data[titleName]);
    }

    private void OnError(PlayFabError error)
    {
        Debug.Log("Error While Reteriving Title Data");
    }
}
