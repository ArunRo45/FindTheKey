using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using System;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public static Login _instance;
    public string currentUserPlayfabId { get; private set; }
    [SerializeField] private float waitTime = 2.3f;

    [SerializeField] private GameObject loadingPanel;
    public static  bool hasLoggedIn = false;


    [SerializeField] private GameObject loginAgainButton;



    [SerializeField] private StartMenuManager startMenuManager;
    private const string titleName = "StartScreenTitleData";
    private void Awake()
    {
        _instance = this;
 
    }


    private void Start()
    {
       
        StartCoroutine(WaitAndHideLoadingPanel(waitTime));

        print("HasLOggedIN : " + hasLoggedIn);
        

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(11);
        }
    }
    public void LoginAccount()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);


    }

    void OnSuccess(LoginResult result)
    {

        hasLoggedIn = true;
        print("Created account");
        currentUserPlayfabId = result.PlayFabId;
        PlayerPrefs.SetString("currentUserPlayFabID", currentUserPlayfabId);
        UpdateHighscore();
        loginAgainButton.SetActive(false);
        startMenuManager.getTitleText(titleName);
        Communication._instance.ShowText("Logged In!",1.2f);

    }

    public void UpdateHighscore()
    {
        if (PlayerPrefs.GetInt(HelperScript.TOTAL_CURRENT_SCORE_VALUE, 0) != 0)
            LeaderBoardManager.instance.SetLeaderBoard(PlayerPrefs.GetInt(HelperScript.TOTAL_CURRENT_SCORE_VALUE));
    }

    void OnError(PlayFabError error)
    {
        print(error.GenerateErrorReport());
        print("Check Your Internet Connection");
        //create a new button for refresh
        Communication._instance.ShowText("Network Error!",2f);

        loginAgainButton.SetActive(true);
    }


    IEnumerator WaitAndHideLoadingPanel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        loadingPanel.SetActive(false);

    }

}
