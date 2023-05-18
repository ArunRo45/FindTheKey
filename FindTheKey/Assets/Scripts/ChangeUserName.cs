using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class ChangeUserName : MonoBehaviour
{

    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject changeNameMenu;



    private void Awake()
    {
        if(PlayerPrefs.GetString(HelperScript.HAS_Playing_FIRST_TIME,"YES") == "YES")
        {
            mainMenu.SetActive(false);
            changeNameMenu.SetActive(true);
        }
        else
        {
            mainMenu.SetActive(true);
            changeNameMenu.SetActive(false);
        }

    }


    public void ChangeDisplayName()
    {
        if (nameInputField.text == "")
        {
            nameInputField.text = "";
            nameInputField.placeholder.GetComponent<TextMeshProUGUI>().SetText("Please Enter Your Name !");
            return;
        }
        if(nameInputField.text.Length > 6)
        {
            print("Enter the name Below 6 Characters");
            nameInputField.text = "";
            nameInputField.placeholder.GetComponent<TextMeshProUGUI>().SetText("Below Six Characters");
            return;
        }

        var namereq = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInputField.text
        };

        PlayFabClientAPI.UpdateUserTitleDisplayName(namereq, OnChangedName, OnError);
    }

    private void OnChangedName(UpdateUserTitleDisplayNameResult result)
    {
        print("Changed Succesfully to : " + result.DisplayName);
        mainMenu.SetActive(true);
        changeNameMenu.SetActive(false);
        PlayerPrefs.SetString(HelperScript.HAS_Playing_FIRST_TIME,"NO");
        PlayerPrefs.SetString(HelperScript.CURRENT_USER_DISPLAY_NAME,result.DisplayName);


    }

    void OnError(PlayFabError error)
    {
        print(error.GenerateErrorReport());
        print("Check Your Internet Connection");
    }
}
