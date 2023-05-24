using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject FinishUI;

    [SerializeField]
    private GameObject PauseUI;

    [SerializeField]
    private GameObject TimerObject;

    [SerializeField]
    private GameObject HighScore;

    [SerializeField]
    private GameObject CurrentScore;

    private bool paused = false;
    public int collected = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            paused = true;
            PauseMenu();
        } else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            paused = false;
            ClosePauseMenu();
        }

    }

    public void FinishMenu()
    {
        TimerObject.SetActive(false);
        Time.timeScale = 0f;
        FinishUI.SetActive(true);
        SoundManager.instance.musicSource.volume = 0;
    }

    public void CloseFinishMenu()
    {
        Time.timeScale = 1f;
        TimerObject.GetComponent<Timer>().StartTimer();
        FinishUI.SetActive(false);
        SoundManager.instance.musicSource.volume = GetMusicVolume();
    }

    public void PauseMenu()
    {
        TimerObject.GetComponent<Timer>().StopTimer();
        Time.timeScale = 0f;
        PauseUI.SetActive(true);
        SoundManager.instance.musicSource.volume = 0;
    }

    public void SetEffectVolume(float i)
    {
        SoundManager.instance.efxSource.volume = i;
        PlayerPrefs.SetFloat("efx", i);
    }

    public void SetMusicVolume(float i)
    {
        SoundManager.instance.musicSource.volume = i;
        PlayerPrefs.SetFloat("music", i);
    }

    public float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat("music", 30f);
    }

    public float GetEffectVolume()
    {
        return PlayerPrefs.GetFloat("efx");
    }

    public void ClosePauseMenu()
    {
        Time.timeScale = 1f;
        TimerObject.GetComponent<Timer>().StartTimer();
        PauseUI.SetActive(false);
        SoundManager.instance.musicSource.volume = GetMusicVolume();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SoundManager.instance.musicSource.volume = GetMusicVolume();
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void ChooseScene(int sceneIndex)
    {
        Time.timeScale = 1f;
        SoundManager.instance.musicSource.volume = GetMusicVolume();
        SceneManager.LoadScene(sceneIndex);
    }

    public void CollectibleCounter()
    {
        Debug.Log("+1");
        collected++;
    }
}
