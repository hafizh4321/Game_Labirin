using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PG
{
    public class UiManager : MonoBehaviour
    {
        public PlayerInventory playerInventory;
        public PlayerStats playerStats;

        [Header("UI Windows")]
        public GameObject selectWindow;
        public GameObject hudWindow;
        public GameObject weaponInventoryWindow;
        public GameObject pauseMenuWindow;

        [Header("Weapon Inventory")]
        public GameObject weaponInventorySlotPrefab;
        public Transform weaponInventorySlotsParent;
        WeaponInventorySlot[] weaponInventorySlots;

        private void Start()
        {
            weaponInventorySlots = weaponInventorySlotsParent.GetComponentsInChildren<WeaponInventorySlot>();
        }

        public void UpdateUi()
        {
            #region Weapon Inventory Slots
            for (int i = 0; i < weaponInventorySlots.Length; i++)
            {
                if (i < playerInventory.weaponsInventory.Count)
                {
                    if (weaponInventorySlots.Length < playerInventory.weaponsInventory.Count)
                    {
                        Instantiate(weaponInventorySlotPrefab, weaponInventorySlotsParent);
                        weaponInventorySlots = weaponInventorySlotsParent.GetComponentsInChildren<WeaponInventorySlot>();
                    }
                    weaponInventorySlots[i].AddItem(playerInventory.weaponsInventory[i]);
                }
                else
                {
                    weaponInventorySlots[i].ClearInventorySlot();
                }
            }


            #endregion
        }

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

        public void CLoseAllInventoryWindows()
        {
            weaponInventoryWindow.SetActive(false);
            pauseMenuWindow.SetActive(false);
        }

        // public void SaveGame()
        // {
        //     SaveSystem.SavePlayer(playerStats);
        // }
    }
}