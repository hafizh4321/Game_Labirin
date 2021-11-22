using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PG
{
    public class UiManager : MonoBehaviour
    {
        public GameObject selectWindow;

        public void OpenSelectWindow()
        {
            selectWindow.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
        }

        public void CLoseSelectWindow()
        {
            selectWindow.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;

        }
    }
}