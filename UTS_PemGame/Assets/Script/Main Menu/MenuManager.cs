using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace PG
{
    public class MenuManager : MonoBehaviour
    {

        public int currentHealth;
        // public HealthBar healthBar;

        public CinemachineBrain mainCamera;
        public CinemachineVirtualCamera frame0_cam;
        public CinemachineVirtualCamera frame1_cam;
        public CinemachineVirtualCamera frame2_cam;
        public CinemachineVirtualCamera frame3_cam;

        public GameObject[] frame;
        public GameObject startButton;
        public EventSystem ES;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.anyKeyDown && frame[0].activeInHierarchy)
            {
                frame[0].SetActive(false);
                frame[1].SetActive(true);
                ES.SetSelectedGameObject(startButton);
                frame0_cam.gameObject.SetActive(false);
                frame1_cam.gameObject.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Escape) && frame[1].activeInHierarchy)
            {
                frame[1].SetActive(false);
                frame[0].SetActive(true);
                frame[2].SetActive(false);
                frame[3].SetActive(false);
                frame1_cam.gameObject.SetActive(false);
                frame0_cam.gameObject.SetActive(true);
                frame2_cam.gameObject.SetActive(false);
                frame3_cam.gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Escape) && frame[2].activeInHierarchy)
            {
                frame[2].SetActive(false);
                frame[3].SetActive(false);
                frame[1].SetActive(true);
                frame[0].SetActive(false);
                frame0_cam.gameObject.SetActive(false);
                frame1_cam.gameObject.SetActive(true);
                frame2_cam.gameObject.SetActive(false);
                frame3_cam.gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Escape) && frame[3].activeInHierarchy)
            {
                frame[2].SetActive(false);
                frame[3].SetActive(false);
                frame[1].SetActive(true);
                frame[0].SetActive(false);
                frame0_cam.gameObject.SetActive(false);
                frame1_cam.gameObject.SetActive(true);
                frame2_cam.gameObject.SetActive(false);
                frame3_cam.gameObject.SetActive(false);
            }
        }
        public void Mulai()
        {
            frame[0].SetActive(false);
            frame[1].SetActive(false);
            frame[3].SetActive(false);
            frame[2].SetActive(true);
            frame0_cam.gameObject.SetActive(false);
            frame1_cam.gameObject.SetActive(false);
            frame3_cam.gameObject.SetActive(false);
            frame2_cam.gameObject.SetActive(true);
        }

        public void About()
        {
            frame[0].SetActive(false);
            frame[1].SetActive(false);
            frame[2].SetActive(false);
            frame[3].SetActive(true);
            frame0_cam.gameObject.SetActive(false);
            frame1_cam.gameObject.SetActive(false);
            frame2_cam.gameObject.SetActive(false);
            frame3_cam.gameObject.SetActive(true);
        }

        public void StartGame()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void LoadPlayer()
        {

            PlayerData data = SaveSystem.LoadPlayer();

            // currentHealth = data.currentHealth;

            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;
            // healthBar.SetCurrentHealth(currentHealth);
        }
    }
}
