using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    [SerializeField] private float waitTime = 1.8f;
    private Animator _animator;
    

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        PlayerInteract playerInteractor = other.GetComponent<PlayerInteract>();
        if (playerInteractor != null && playerInteractor.IsPLayerGotKey)//Checks the triggered object is player
        {
            HandleWon(other);

        }
    }

    private void HandleWon(Collider2D player)
    {
        player.gameObject.SetActive(false);
        //Playing door open animation
        _animator.SetTrigger("OpenDoor");
        //loading next scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(WaitAndLoadNextScene(currentSceneIndex));
    }


    IEnumerator WaitAndLoadNextScene(int currentSceneIndex)
    {
        //Debug.Log("in Coroutine");
        yield return new WaitForSeconds(waitTime);
        SceneLoader.instance.LoadNextScene(currentSceneIndex);
    }
}
