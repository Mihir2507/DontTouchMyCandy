using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    public void PauseGame(){
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame(){
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame(){
        Application.Quit();
    }
}
