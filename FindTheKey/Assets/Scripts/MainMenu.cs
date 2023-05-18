using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator mainMenuAnimator;
    [SerializeField] private Animator optionsMenuAnimator;


    private void Awake()
    {

    }

    public void ShowOptionsMenu()
    {
        mainMenuAnimator.SetTrigger(HelperScript.MAIN_MENU_HIDE_TAG);
        optionsMenuAnimator.SetTrigger(HelperScript.OPTIONS_MENU_SHOW_TAG);
    }

    public void BackButton()
    {

        optionsMenuAnimator.SetTrigger(HelperScript.OPTIONS_MENU_HIDE_TAG);
        mainMenuAnimator.SetTrigger(HelperScript.MAIN_MENU_SHOW_TAG);

    }

}
