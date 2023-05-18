using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{

    private int currentSceneIndex;
    private bool isGameStarted = false;
    private float time;
    private string timeString;
    public int CurrentSceneIndex//getter for currentSceneIndex
    {
        get
        {
            return currentSceneIndex;
        }
        
    }

    private TextMeshProUGUI _levelIndicatorText;
    private TextMeshProUGUI _coinIndicatorText;
    private TextMeshProUGUI _timerText;


    double totalTimeInSeconds;

    public static UiManager instance;

    private void Awake()
    {
        #region SingleTonPattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        

        #endregion;
        if(FindObjectOfType<PlayerInteract>() != null)
            PlayerInteract.OnGameStarted += OnGameStarted;
    }

    private void OnGameStarted()
    {

        ShowLevelText();
        ShowCoinText();
        SetTimerText();
        isGameStarted = true;
    }
    
    
    private  void ShowLevelText()//TODO : call this on every level starts
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (_levelIndicatorText == null && currentSceneIndex > 0)
        {
            if (GameObject.FindGameObjectWithTag("levelText"))
                _levelIndicatorText = GameObject.FindGameObjectWithTag("levelText").GetComponent<TextMeshProUGUI>();

        }
        if (_levelIndicatorText != null)
            _levelIndicatorText.text = "LEVEL : " + currentSceneIndex;
    }

    public void ShowCoinText()
    {
        _coinIndicatorText = GameObject.FindWithTag("CoinText").GetComponent<TextMeshProUGUI>();
        _coinIndicatorText.SetText("COINS : "+ GameHandler.instance.Coins);
    }


    private void SetTimerText()
    {
        _timerText = GameObject.FindGameObjectWithTag("timerText").GetComponent<TextMeshProUGUI>();
    }


    private void Update()
    {
        if(isGameStarted)
            StartTimer();
    }
    private void StartTimer()
    {
        time += Time.deltaTime;
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        totalTimeInSeconds = minutes * 60 + seconds;

        timeString = $"{minutes} : {seconds}  ";
        _timerText.SetText(timeString);
    }

    public double GetTotalTimeInSeconds()
    {
        return totalTimeInSeconds;
    }

}
