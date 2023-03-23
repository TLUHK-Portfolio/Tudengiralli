using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject FinishUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            FinishMenu();
        }
    }

    public void FinishMenu()
    {
        FinishUI.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void ChooseScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
