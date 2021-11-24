using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace PG
{
    public class PlayerStats : MonoBehaviour
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        public HealthBar healthBar;
        public PlayerLocomotion playerLocomotion;
        public GameOverScreen gameOverScreen;

        public GameObject selectWindow;


        AnimatorHandler animatorHandler;


        private void Awake()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }

        void Start()
        {
            // if(sceneloader)
            maxHealth = setMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        private int setMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;

            healthBar.SetCurrentHealth(currentHealth);

            animatorHandler.PlayTargetAnimation("Damage_01", true);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayTargetAnimation("Dead_01", true);
                gameOverScreen.GameoverShow();
            }
        }

        public void SavePlayer()
        {
            SaveSystem.SavePlayer(this);
            playerLocomotion.SetCurrentEnergy();

        }

        public void LoadPlayer()
        {
            // selectWindow.SetActive(false);
            // Cursor.lockState = CursorLockMode.Confined;
            // Time.timeScale = 1f;
            // SceneManager.LoadScene("SampleScene");

            PlayerData data = SaveSystem.LoadPlayer();

            currentHealth = data.currentHealth;

            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;
            healthBar.SetCurrentHealth(currentHealth);
            playerLocomotion.CurrentEnergy();



        }
    }
}