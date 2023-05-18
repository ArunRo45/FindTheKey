using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuUi;

    private void Start()
    {
        Time.timeScale = 1;
        pauseMenuUi.SetActive(false);
    }
    public void OnPauseClick()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnResumeClick()
    {
        Time.timeScale = 1;
        pauseMenuUi.SetActive(false);
    }
}
