
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    
    public Image keyImg;

    private void Start()
    {
 
        PlayerInteract.OnPlayerGotKey += PlayerGotKey;
    }

    public void PlayerGotKey()
    {
        //Debug.Log("Key is disabled");
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        PlayerInteract.OnPlayerGotKey -= PlayerGotKey;
    }


}
