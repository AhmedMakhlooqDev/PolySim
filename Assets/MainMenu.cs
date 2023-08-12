using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingscreen;
    public Image loading;

    public GameObject ControlsPanel, buttons, creditPanel;
    public void PlayGame()
    {
        StartCoroutine(LoadAsync(1));
        QuestMenuHandler.pauseMenuStatus = false;
        Time.timeScale = 1;
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        ControlsPanel.SetActive(true);
        buttons.SetActive(false);
    }

    public void Credits()
    {
        creditPanel.SetActive(true);
        buttons.SetActive(false);
    }

    public void BackButton()
    {
        creditPanel.SetActive(false);
        ControlsPanel.SetActive(false);
        buttons.SetActive(true);
    }

    

    IEnumerator LoadAsync (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingscreen.SetActive(true);

        while (!operation.isDone)
        {
            //loading.rectTransform.Rotate(new Vector3(0, 0, 1)); 
            yield return null;
        }
    }


}
