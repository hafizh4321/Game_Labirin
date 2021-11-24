using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace PG
{
    public class GameOverScreen : MonoBehaviour
    {
        public void GameoverShow()
        {
            gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 1f;
        }

        public void RestartButton()
        {
            SceneManager.LoadScene("SampleScene");
        }
        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}