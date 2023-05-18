using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    
    public static SceneLoader instance; //TODO : later use getter and setter

    

    private void Awake()
    {
        #region Singleton Pattern
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }


    public void PlayGame()
    {
        //Save Scene Key gives us finised scene index so we need to load the next scene from the saved scene index
        SceneManager.LoadScene(/*PlayerPrefs.GetInt(HelperScript.SAVE_SCENE_NAME_KEY,1) + */1);
    }

    public void QuitGame()
    {
        Debug.Log("Qutting..");

        Application.Quit();
    }
    public void LoadNextScene(int currentSceneIndex)
    {
        //Debug.Log("In Scene Loader class");
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

}
