using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class CreateLeaderBoardUI : MonoBehaviour
{

    [SerializeField] private Transform highscoreTemplate;
    [SerializeField] private Transform Parent;
    public List<PlayerData> playerDataList;
    private void Awake()
    {
        playerDataList = new List<PlayerData>();
        highscoreTemplate.gameObject.SetActive(false);

        LeaderBoardManager.OnPlayerLeaderBoardGet += OnLeaderBoardGet;

    }


    private void OnLeaderBoardGet()
    {
        this.playerDataList = LeaderBoardManager.instance.playerDataList;
        playerDataList.Reverse();

        foreach(PlayerData player in playerDataList)
        {
            CreateUITemplate(player);
        }
    }

    public void CreateUITemplate(PlayerData player)
    {
        Transform template = Instantiate(highscoreTemplate, Parent);
        template.gameObject.SetActive(true);
        template.Find("time").GetComponent<TextMeshProUGUI>().SetText(player.playerStatValue.ToString());
        if (PlayerPrefs.GetString(HelperScript.CURRENT_USER_DISPLAY_NAME) == player.playerName)
        {
            template.GetComponent<Image>().color = Color.black;

            template.Find("name").GetComponent<TextMeshProUGUI>().SetText(player.playerName + "(YOU)");
        }
        else
        {

            template.Find("name").GetComponent<TextMeshProUGUI>().SetText(player.playerName);
        }

    }

    private void OnDisable()
    {
        LeaderBoardManager.OnPlayerLeaderBoardGet -= OnLeaderBoardGet;
    }
    private void OnDestroy()
    {
        LeaderBoardManager.OnPlayerLeaderBoardGet -= OnLeaderBoardGet;
    }
}
