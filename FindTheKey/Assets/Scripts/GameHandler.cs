using System.Collections;
using UnityEngine;
public class GameHandler : MonoBehaviour
{

    public static GameHandler instance;
    public int totalCoins;
    private int _coins = 0;

    public int Coins
    {
        get
        {
            return _coins;
        }
        set
        {
            _coins += value;
            UiManager.instance.ShowCoinText();
            //Debug.Log("Coin : "+ _coins);
        }
    }
   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       

    }

    private void Start()
    {
        Login._instance.LoginAccount();
        print("IN Game Handeler start");
        totalCoins = PlayerPrefs.GetInt(HelperScript.PLYAER_COINS_KEY);
        PlayerInteract.OnGameStarted += OnGameStarted;
    }

    private void OnGameStarted()
    {
        _coins = 0;
        //so we can start every level as _coins = 0;
    }


    public void PlayerDied()
    {
        AudioManager.Instance.PlayDeathSound();
        GameObject.FindWithTag("Player").gameObject.SetActive(false);
        StartCoroutine(WaitAndShowGameOverUI());
        
    }

    IEnumerator WaitAndShowGameOverUI()
    {
        yield return new WaitForSeconds(0.4f);//wait time to show the gameover Panel
        GameOverUI.instance.ShowGameOverPanel();
    }

    // public void AddScore(int amount)
    // {
    //     _coins += amount;
    // }

    

 
}
