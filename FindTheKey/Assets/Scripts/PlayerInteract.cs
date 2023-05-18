using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour 
{

    public static Action OnPlayerGotKey;
    public static Action OnGameStarted;
    public static Action OnPlayerWon;
    public static Action OnPLayerWonFinalLevel;
    public bool IsPLayerGotKey { private set; get; }
    public int coinScoreValue = 1;

    private void Awake()
    {
        IsPLayerGotKey = false;
    }

    private void Start()
    {
        Debug.Log("Current coins : " + PlayerPrefs.GetInt(HelperScript.PLYAER_COINS_KEY));
        //call the event whenever the player is on the first frame of the game
        OnGameStarted?.Invoke();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        switch(other.gameObject.tag)
        {
            case HelperScript.KEY_TAG:
                IsPLayerGotKey = true;
                OnPlayerGotKey?.Invoke();
                break;
            
            case HelperScript.COIN_TAG:
                HandleScore(other);
                AudioManager.Instance.PlayPickUpSOund();
                break;
            
            case HelperScript.WATER_TAG:
                GameHandler.instance.PlayerDied();
                break;
            
            case HelperScript.TRIGGER_TAG:
                HandleTrigger(other);
                break;
            
            case HelperScript.DOOR_TAG:
                if (!IsPLayerGotKey)
                    Debug.Log("Take The Key First");
                else if (IsPLayerGotKey)
                {
                    if (SceneLoader.instance.GetCurrentSceneIndex() == 10)//10 is last scene index of our game
                        OnPLayerWonFinalLevel?.Invoke();
                    OnPlayerWon?.Invoke();
                }
                break;
                
        }

        
        

    }
    private void HandleScore(Collider2D coin)
    {
        GameHandler.instance.Coins = coinScoreValue; 
        Destroy(coin.gameObject);
    }

    

    private void HandleTrigger(Collider2D other)
    {
        //Playing the open animation
        Animator trigger = other.gameObject.GetComponent<Animator>();
        trigger.SetBool("Open", true);
        FindObjectOfType<Trigger>().SetHiddenPlatform();

    }

 
}
