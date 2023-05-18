using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreButtonController : MonoBehaviour
{
    private bool isHighScorePanelOn = false;
    [SerializeField] private GameObject highScoreContatiner;


    public void OnHighScoreClick()
    {
        StartCoroutine(WaitAnShowHighScore(2f));

        isHighScorePanelOn = !isHighScorePanelOn;
        highScoreContatiner.SetActive(isHighScorePanelOn);
    }

    
    IEnumerator WaitAnShowHighScore(float waitTime)
    {


        yield return new WaitForSeconds(waitTime);

        if (isHighScorePanelOn)
        {

            Login._instance.UpdateHighscore();
            LeaderBoardManager.instance.GetLeaderBoard();
        }

    }


}
