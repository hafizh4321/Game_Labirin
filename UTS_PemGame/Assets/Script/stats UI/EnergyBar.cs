using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PG
{
    public class EnergyBar : MonoBehaviour
    {
        public Image currentEnergy;
        public float energyCurrent;
        public float energy = 74;
        public float maxEnergy = 74;
        public Slider slider;
        public float ratio;
        public float ratioCurrent;

        public PlayerManager playerManager;

        void Update()
        {
            EnergyDrain();
            UpdateEnergy();
        }

        private void EnergyDrain()
        {
            if (playerManager.isSprinting == true)
            {
                if (energy < 75 && energy > 0)
                {
                    energy -= 15 * Time.deltaTime;
                    // energyCurrent = energy;
                }
            }
            else if (energy < 75 && energy > 0)
            {
                energy += 10 * Time.deltaTime;
                // energyCurrent = energy;

            }
            else if (energy < 1)
            {
                energy = 1;
            }
            else
            {
                energy = maxEnergy;

            }
        }

        private void UpdateEnergy()
        {
            ratio = energy / maxEnergy;
            currentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
        }

        public void SetCurrentEnergy()
        {
            energyCurrent = energy;
            ratioCurrent = ratio;
        }

        public void CurrentEnergy()
        {
            energy = energyCurrent;
            ratio = ratioCurrent;
            slider.value = ratio;

        }
    }
}
