using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace PG
{
    public class GameOverScreen : MonoBehaviour
    {
        // public UiManager uiManager;
        public GameObject selectWindow;

        public void GameoverShow()
        {
            gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
        }

        public void RestartButton()
        {
            selectWindow.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            SceneManager.LoadScene("SampleScene");
        }
        public void MainMenu()
        {
            // uiManager.CLoseSelectWindow();

            selectWindow.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");

        }
    }
}