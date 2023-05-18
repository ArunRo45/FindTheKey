using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
public class SendAndReceiveuserData : MonoBehaviour
{
    //public static Action OnDataLoaded;

    //public static SendAndReceiveuserData instance;
    //private string currentPlayerPlayFabID;
    
    //public List<double> playerTimes;


    //private void Awake()
    //{
    //    instance = this;
    //    playerTimes  = new List<double>();
    //}

    //private void Start()
    //{
    //    LeaderBoardManager.OnPlayerLeaderBoardGet += OnLeaderBoardGet;
    //}

    //void Update()
    //{

    //}

    //public void GetTimeScorevalue(string playerid)
    //{
    //    currentPlayerPlayFabID = playerid;

    //    var request = new GetUserDataRequest
    //    {
    //        PlayFabId = playerid
    //    };
    //    PlayFabClientAPI.GetUserData(request, OnDataRecived, OnError);

    //}

    //private void OnDataRecived(GetUserDataResult result)
    //{
    //    if (result != null)
    //    {
    //        //print(result.Data["timeValue"].Value);
    //        float timeValue = float.Parse(result.Data["timeValue"].Value);
    //        //print(timeValue);
    //        playerTimes.Add(timeValue);
    //        //print("Size of double times "+ playerTimes.Count);
    //    }

    //    if (playerTimes.Count == LeaderBoardManager.instance.totalPlayers)
    //        OnDataLoaded?.Invoke();
    //}

    //public void SetTimeScoreValue(double timeValue)
    //{
    //    var request = new UpdateUserDataRequest
    //    {
    //        Data = new Dictionary<string, string>
    //        {
    //            { "timeValue", timeValue.ToString() }
    //        }
    //        ,
    //        Permission = UserDataPermission.Public //making the all user time value to public 
    //    };

    //    PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    //}

    //private void OnError(PlayFabError obj)
    //{
    //    print("error occurs while saving data");
    //}

    //private void OnDataSend(UpdateUserDataResult obj)
    //{
    //    print("data sent Successflly");
    //}


    //private void OnLeaderBoardGet()
    //{
    //    foreach(string id in LeaderBoardManager.instance.getPlayersId())
    //    {
    //        GetTimeScorevalue(id);
    //    }


    //}

    //public List<double> GetPlayerTimes()
    //{
    //    return playerTimes;
        
    //}

    //private void OnDisable()
    //{
    //    playerTimes.Clear();
    //}

}



