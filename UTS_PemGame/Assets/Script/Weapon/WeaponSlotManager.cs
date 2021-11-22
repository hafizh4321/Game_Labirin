using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PG
{
    public class WeaponSlotManager : MonoBehaviour
    {
        WeaponHolderSlot leftHandSlot;
        WeaponHolderSlot rightHandSlot;

        QuickSLotsUi quickSLotsUi;

        private void Awake()
        {
            quickSLotsUi = FindObjectOfType<QuickSLotsUi>();
            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
            foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if (weaponSlot.isLeftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }
                else if (weaponSlot.isRightHandSlot)
                {
                    rightHandSlot = weaponSlot;
                }
            }
        }

        public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.LoadWeaponModel(weaponItem);
                quickSLotsUi.UpdateWeaponQuickSlotsUI(true, weaponItem);
            }
            else
            {
                rightHandSlot.LoadWeaponModel(weaponItem);
                quickSLotsUi.UpdateWeaponQuickSlotsUI(false, weaponItem);
            }
        }
    }
}