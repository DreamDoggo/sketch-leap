using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [Tooltip("How long to wait in seconds after a button is pressed before playing its sound effect")]
    [SerializeField] public float ButtonClickSoundDelay = .1f;
    [SerializeField] public AudioClip ButtonClickSound;

    private AudioSource SFXPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 2)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
        SFXPlayer = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        PlayButtonSoundEffect(ButtonClickSound, ButtonClickSoundDelay);
        SceneManager.LoadScene("sketch-leap");
    }

    public void GotToTips()
    {
        PlayButtonSoundEffect(ButtonClickSound, ButtonClickSoundDelay);
        SceneManager.LoadScene("TipsScreen");
    }

    public void GoToMenu()
    {
        PlayButtonSoundEffect(ButtonClickSound, ButtonClickSoundDelay);
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToCredits()
    {
        PlayButtonSoundEffect(ButtonClickSound, ButtonClickSoundDelay);
        SceneManager.LoadScene("Credits");
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0) 
        {
            PlayButtonSoundEffect(ButtonClickSound, ButtonClickSoundDelay);
        }
    }

    public void PlayButtonSoundEffect(AudioClip soundEffect, float delay) 
    {
        if (soundEffect != null) 
        {
            SFXPlayer.clip = soundEffect;
            SFXPlayer.PlayDelayed(delay);
        }
    }
}
