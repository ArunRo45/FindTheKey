
using UnityEngine;

public class AudioManager : MonoBehaviour
{


    private static AudioManager _instance;

    public static AudioManager Instance 
    {
        get
        {
            if (_instance == null)
                Debug.LogError("AudioManager Is NULL");

            return _instance;
        }
    }
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip coinPickSound;
    [SerializeField] private AudioClip jumpSound;

    [SerializeField] private AudioSource playerAudioSource;



    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(SceneLoader.instance.GetCurrentSceneIndex() == 0)
            Destroy(gameObject);
    }

    public void PlayDeathSound()
    {
        playerAudioSource.clip = deathSound;
        playerAudioSource.Play();
        //Debug.Log("playing death sound");
    }

    public void PlayPickUpSOund()
    {
        playerAudioSource.clip = coinPickSound;
        playerAudioSource.Play();
        //Debug.Log("playing pickUp sound");
    }

    public void PlayJumpSound()
    {
        playerAudioSource.clip = jumpSound;
        playerAudioSource.Play();
        //Debug.Log("playing jump sound");
    }


}
