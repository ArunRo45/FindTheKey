using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class LeaderBoardManager : MonoBehaviour
{
    public static Action OnPlayerLeaderBoardGet;
    public static LeaderBoardManager instance;
    public int totalPlayers { get; private set; }
    public List<PlayerData> playerDataList;

    public string playerId;


    private void Awake()
    {
        playerDataList = new List<PlayerData>();
        instance = this;
    }
    private void Start()
    {
        totalPlayers = 0;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) //TODO: delete this after testing
            SetLeaderBoard(1000);
    }
    

    void OnError(PlayFabError error)
    {
        print("Check Your Internet Connection");
        Communication._instance.ShowText("Network Error!", 2f);
    }


    //LeaderBoard 

    public void SetLeaderBoard(int timeScore)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "timeScore",
                    Value = timeScore
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
    }

    void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        print("Succeded Update LeadBoard");

    }
    public void GetLeaderBoard()
    {
        //getting leaderboard
        var request = new GetLeaderboardRequest
        {
            StatisticName = "timeScore",
            StartPosition = 0,
            MaxResultsCount = 99

        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnError);
    }

    private void OnLeaderBoardGet(GetLeaderboardResult result)
    {

        foreach (var item in result.Leaderboard)
        {
            playerDataList.Add(new PlayerData(item.DisplayName, item.StatValue));
            //CreateLeaderBoardUI.Instance.CreateUITemplate(item.DisplayName, item.StatValue);
        }

        totalPlayers = result.Leaderboard.Count;
        if (totalPlayers == playerDataList.Count)
            OnPlayerLeaderBoardGet?.Invoke();
    }
}
